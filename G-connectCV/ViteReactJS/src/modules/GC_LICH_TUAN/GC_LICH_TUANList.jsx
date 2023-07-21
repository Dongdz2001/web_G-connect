﻿import React, { useState, useEffect, useRef } from "react";
import dayjs from "dayjs";
import utc from "dayjs/plugin/utc";
import { Card } from "primereact/card";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { Button } from "primereact/button";
import { InputText } from "primereact/inputtext";
import { InputTextarea } from "primereact/inputtextarea";
import { Dialog } from "primereact/dialog";
import { Link } from "react-router-dom";
import { Dropdown } from "primereact/dropdown";
import { Toast } from "primereact/toast";
import { useTranslation } from "react-i18next";
import { mapPaginator } from "shared/utils";
import Permission from "components/Permission";
import { Calendar } from "components/Calendar";
import { useSelector, useDispatch } from "react-redux";
import { setParamState } from "store/listParamSlice";
import { decodeUnicode } from "shared/utils/decodeHtmlEntites";
import { confirmDialogGlobal } from "shared/components/confirmDialogGlobal";
import { DEFAULT_LIST_PARAM, DEFAULT_LIST_PAGE } from "shared/app-settings";

import GC_LICH_TUANFormView from "modules/GC_LICH_TUAN/GC_LICH_TUANFormView";
import GC_LICH_TUANForm from "modules/GC_LICH_TUAN/GC_LICH_TUANForm";
import { GC_LICH_TUANService } from "modules/GC_LICH_TUAN/GC_LICH_TUANService";
import { ColumnGroup } from "primereact/columngroup";
import { Row } from "primereact/row";

dayjs.extend(utc);
const GC_LICH_TUANList = (props) => {
  const { t, i18n } = useTranslation();
  const openDialog = false;
  const fieldID = "id";
  const fieldSort = "id";
  const fieldSortOrder = "ASC";
  const linkEdit = "/admin/GC_LICH_TUAN-form";
  const linkView = "/admin/GC_LICH_TUAN-view";
  const showAdvancedSearchButton = true;
  const codePermAdd = "PERM_GC_LICH_TUAN_ADD";
  const codePermModify = "PERM_GC_LICH_TUAN_MOD";
  const codePermDel = "PERM_GC_LICH_TUAN_DEL";
  const deleteMsg = "Bạn có chắc chắn xoá bản ghi này không?";
  const titlePage = "Danh sách Lịch tuần, lịch thực tập";
  const labelAdd = "Thêm bản ghi";
  const labelDelete = "Xóa bản ghi";
  const labelKeyword = "Từ khoá...";
  const labelFind = "Tìm kiếm nâng cao";
  const labelFindButton = "Tìm kiếm";
  const columnBodyDate = (date) => {
    return dayjs(date).format("DD/MM/YYYY HH:mm");
  };
  const columnBodyState = (rowData) => {
    if (rowData) {
      return <i className="pi pi-lock" title={"Bị khoá"}></i>;
    } else return <>Good</>;
  };
  const dialogFooterView = (
    <div className="flex justify-content-center">
      <Button
        label="OK"
        className="p-button-text"
        autoFocus
        onClick={() => setShowDialogView(false)}
      />
    </div>
  );
  const dialogFooterEdit = (
    <div className="flex justify-content-center">
      <Button
        label="OK"
        className="p-button-text"
        autoFocus
        onClick={() => setShowDialogEdit(false)}
      />
    </div>
  );
  /**/
  /**/
  const dispatch = useDispatch();
  const toast = useRef(null);
  const listParamStore = useSelector((state) => {
    var param = null;
    if (
      state.listParam.find((st) => st && st.name == window.location.toString())
    )
      param = state.listParam.find(
        (st) => st && st.name == window.location.toString()
      ).param;
    return param;
  });
  const [loading, setLoading] = useState(false);
  const [showDialogView, setShowDialogView] = useState(false);
  const [showDialogEdit, setShowDialogEdit] = useState(false);
  const [showAdvancedSearch, setShowAdvancedSearch] = useState(false);
  const [listItems, setListItems] = useState(null);
  const [totalItems, setTotalItems] = useState(0);
  const [selectedItems, setSelectedItems] = useState([]);
  const [selectedId, setSelectedId] = useState(null);
  const [listRef_id_nguoi_thuc_hien, setListRef_id_nguoi_thuc_hien] = useState(
    []
  );
  const [aDVSParams, setADVSParams] = useState({});
  const [lazyParams, setLazyParams] = useState({
    ...DEFAULT_LIST_PARAM,
    ...{
      sortField: fieldSort,
      sortOrder: fieldSortOrder == "ASC" ? -1 : 1,
    },
    ...listParamStore,
  });
  useEffect(() => {
    loadLazyData();
  }, [lazyParams.refresh]);
  useEffect(() => {
    setTimeout(() => {
      if (listParamStore && listParamStore.pageYOffset)
        window.scrollTo(0, listParamStore.pageYOffset);
    }, 100);

    getListRef_id_nguoi_thuc_hien();
  }, [window.location.href]);

  const loadLazyData = () => {
    setLoading(true);
    let advanceSearch = mapPaginator(lazyParams);
    return GC_LICH_TUANService.filterPage(advanceSearch).then((res) => {
      setTotalItems(res.data.meta.total);
      setListItems(res.data.data);
      setLoading(false);
    });
  };

  const getListRef_id_nguoi_thuc_hien = () => {
    return GC_LICH_TUANService.getAllRef_id_nguoi_thuc_hien().then((res) => {
      res.data.map((x) => {
        x.Value = x.value;
        x.Text = x.label;
      });
      setListRef_id_nguoi_thuc_hien(res.data);
    });
  };
  const onPage = (event) => {
    setLazyParams({ ...lazyParams, ...event, refresh: Date.now() });
  };
  const onSort = (event) => {
    setLazyParams({ ...lazyParams, ...event, refresh: Date.now() });
  };
  const onFilter = (event) => {
    setLazyParams({ ...lazyParams, page: 0, first: 0, refresh: Date.now() });
  };
  const onChangeKeySearch = (text) => {
    //debugger
    setLazyParams({ ...lazyParams, keySearch: text });
  };
  const onEnterKeySearch = (event) => {
    //debugger
    if (event.key === "Enter") {
      onFilter();
    }
    //Backspace
  };
  const onSelectionChange = (event) => {
    const value = event.value;
    setSelectedItems(value);
  };
  const onShowAdvancedSearch = (event) => {
    setShowAdvancedSearch(!showAdvancedSearch);
  };
  const editItem = async (id) => {
    setSelectedId(id);
    dispatch(setParamState({ ...lazyParams, pageYOffset: window.pageYOffset }));
    if (openDialog) setShowDialogEdit(true);
  };
  const viewItem = async (id) => {
    setSelectedId(id);
    dispatch(setParamState({ ...lazyParams, pageYOffset: window.pageYOffset }));
    if (openDialog) setShowDialogView(true);
  };
  const closeDialog = async () => {
    if (openDialog) setShowDialogEdit(false);
    if (openDialog) setShowDialogView(false);
  };
  const deleteItem = async (id) => {
    await GC_LICH_TUANService.delete(id);
    loadLazyData();
  };
  const deleteItems = async (items) => {
    for (var i = 0; i < items.length; i++) {
      await GC_LICH_TUANService.delete(items[i][fieldID]);
    }
    loadLazyData();
  };
  const confirmDelete = (data) => {
    confirmDialogGlobal({
      message: deleteMsg,
      accept: () =>
        data ? deleteItem(data[fieldID]) : deleteItems(selectedItems),
      rejectClassName: "btnClose",
      acceptClassName: "p-button-danger",
    });
  };
  const paginatorLeft = (
    <>
      <Button
        type="button"
        icon="pi pi-refresh"
        className="p-button-text p-button-secondary"
        onClick={() => loadLazyData()}
      />
      <Dropdown
        options={DEFAULT_LIST_PAGE}
        className="mr-2"
        value={lazyParams.rows}
        onChange={(e) =>
          setLazyParams({ ...lazyParams, first: 0, page: 1, rows: e.value })
        }
      />
    </>
  );
  const actionBodyTemplate = (rowData) => {
    return (
      <React.Fragment>
        <div className="flex flex-row justify-content-end">
          <Link
            to={openDialog ? null : linkEdit + "/" + rowData[fieldID]}
            onClick={() => editItem(rowData[fieldID])}
          >
            <i className="p-button-rounded p-button p-button-text p-1 pi pi-pencil mr-2 flex align-items-center"></i>
          </Link>
          <Link
            to={openDialog ? null : linkView + "/" + rowData[fieldID]}
            onClick={() => viewItem(rowData[fieldID])}
          >
            <i className="p-button-rounded p-button p-button-text p-1 pi pi-info-circle mr-2 flex align-items-center"></i>
          </Link>
          <a onClick={() => confirmDelete(rowData)}>
            <i className="p-button-rounded p-button p-button-text p-1 pi pi-trash mr-2 flex align-items-center p-button-danger p-button-outlined"></i>
          </a>
        </div>
      </React.Fragment>
    );
  };
  const headerGroup = (
    <ColumnGroup>
      <Row>
        <Column className="text-center" rowSpan={2} header="TT" />
        <Column
          rowSpan={2}
          selectionMode="multiple"
          headerStyle={{ width: "3em" }}
        />
        <Column
          className="text-center"
          rowSpan={2}
          field="id_nguoi_thuc_hien"
          header="Nhân viên"
        />
        <Column
          className="text-center"
          colSpan={2}
          field="thu2"
          header={"Thứ 2"}
        />
        <Column
          className="text-center"
          colSpan={2}
          field="thu3"
          header={"Thứ 3"}
        />
        <Column
          className="text-center"
          colSpan={2}
          field="thu4"
          header={"Thứ 4"}
        />
        <Column
          className="text-center"
          colSpan={2}
          field="thu5"
          header={"Thứ 5"}
        />
        <Column
          className="text-center"
          colSpan={2}
          field="thu6"
          header={"Thứ 6"}
        />
        <Column
          className="text-center"
          colSpan={2}
          field="thu7"
          header={"Thứ 7"}
        />
        <Column
          className="text-center"
          field="so_dien_thoai"
          rowSpan={2}
          header="Số điện thoại"
        />
        <Column
          className="text-center"
          field="link_bao_cao"
          rowSpan={2}
          header="Link báo cáo"
        />
        <Column
          rowSpan={2}
          style={{ width: "80px" }}
          className={"text-center"}
          header={<i className="pi pi-cog"></i>}
          exportable={false}
        />
      </Row>
      <Row>
        <Column className="text-center" field="thu2_sang" header="Sáng" />
        <Column className="text-center" field="thu2_chieu" header="Chiều" />
        <Column className="text-center" field="thu3_sang" header="Sáng" />
        <Column className="text-center" field="thu3_chieu" header="Chiều" />
        <Column className="text-center" field="thu4_sang" header="Sáng" />
        <Column className="text-center" field="thu4_chieu" header="Chiều" />
        <Column className="text-center" field="thu5_sang" header="Sáng" />
        <Column className="text-center" field="thu5_chieu" header="Chiều" />
        <Column className="text-center" field="thu6_sang" header="Sáng" />
        <Column className="text-center" field="thu6_chieu" header="Chiều" />
        <Column className="text-center" field="thu7_sang" header="Sáng" />
        <Column className="text-center" field="thu7_chieu" header="Chiều" />
      </Row>
    </ColumnGroup>
  );
  /**/
  return (
    <Card title={titlePage}>
      <Toast ref={toast} />
      <Dialog
        visible={showDialogView}
        onHide={() => setShowDialogView(false)}
        position="top"
        showHeader={false}
        showFooter={false}
        breakpoints={{ "960px": "80vw" }}
        style={{ width: "50vw" }}
      >
        <div className="flex justify-content-center flex-column pt-6 px-3">
          <GC_LICH_TUANFormView
            id={selectedId}
            fnClose={closeDialog}
          ></GC_LICH_TUANFormView>
        </div>
      </Dialog>
      <Dialog
        visible={showDialogEdit}
        onHide={() => setShowDialogEdit(false)}
        position="top"
        showHeader={false}
        showFooter={false}
        breakpoints={{ "960px": "80vw" }}
        style={{ width: "70vw" }}
      >
        <div className="flex justify-content-center flex-column pt-6 px-3">
          <GC_LICH_TUANForm
            id={selectedId}
            fnClose={closeDialog}
          ></GC_LICH_TUANForm>
        </div>
      </Dialog>
      <div className="row mb-2">
        <div className="col-12 col-sm-5">
          <div className="p-inputgroup">
            <InputText
              autoFocus
              placeholder={labelKeyword}
              onKeyDown={onEnterKeySearch}
              onChange={(e) => onChangeKeySearch(e.target.value)}
              value={lazyParams.keySearch ?? ""}
            />
            <Button
              icon="pi pi-search"
              className="p-button-outlined p-button-secondary"
              onClick={() => onFilter()}
            />
            {showAdvancedSearchButton && (
              <Button
                icon={
                  showAdvancedSearch == true
                    ? "fas fa-folder"
                    : "far fa-folder-open"
                }
                className="p-button-outlined p-button-secondary"
                onClick={() => onShowAdvancedSearch()}
                title={labelFind}
                style={{ left: "-1px" }}
              />
            )}
          </div>
        </div>
        <div className="col-12 col-sm-7 text-right">
          <Permission code={codePermAdd}></Permission>
          <Link to={linkEdit + "/new"}>
            <Button icon="fa fa-plus" label={labelAdd} />
          </Link>
        </div>
      </div>
      {showAdvancedSearch == true && (
        <div className="row mb-2 advancedSearchBox">
          <div className="col-12 col-sm-12">
            <h5 className="card-title">{labelFind}</h5>
          </div>

          <div className="col-12 col-sm-2">
            <div className="field">
              <span className="p-float-label p-input-icon-right">
                <i className="pi pi1-envelope" />
                <Dropdown
                  options={listRef_id_nguoi_thuc_hien}
                  optionValue="Value"
                  optionLabel="Text"
                  scrollHeight={"600px"}
                  className=""
                  value={lazyParams.id_nguoi_thuc_hien}
                  onChange={(e) => {
                    var filter = {
                      ...aDVSParams,
                      id_nguoi_thuc_hien: e.target.value,
                    };
                    setADVSParams(filter);
                    setLazyParams({
                      ...lazyParams,
                      filter: filter,
                    });
                  }}
                  placeholder="--Chọn--"
                  showClear
                />
                <label htmlFor="id_nguoi_thuc_hien">Nhân viên</label>
              </span>
            </div>
          </div>
          <div className="col-12 col-sm-1">
            <div className="field">
              <span className="p-float-label p-input-icon-right">
                <i className="pi pi1-envelope" />
                <InputText
                  name="thu2_sang"
                  onChange={(e) => {
                    var filter = {
                      ...aDVSParams,
                      thu2_sang: e.target.value,
                    };
                    setADVSParams(filter);
                    setLazyParams({
                      ...lazyParams,
                      filter: filter,
                    });
                  }}
                  value={aDVSParams.thu2_sang ?? ""}
                />
                <label htmlFor="thu2_sang">Thứ 2</label>
              </span>
            </div>
          </div>
          <div className="col-12 col-sm-2">
            <div className="field">
              <span className="p-float-label p-input-icon-right">
                <i className="pi pi1-envelope" />
                <InputText
                  name="thu2_chieu"
                  onChange={(e) => {
                    var filter = {
                      ...aDVSParams,
                      thu2_chieu: e.target.value,
                    };
                    setADVSParams(filter);
                    setLazyParams({
                      ...lazyParams,
                      filter: filter,
                    });
                  }}
                  value={aDVSParams.thu2_chieu ?? ""}
                />
                <label htmlFor="thu2_chieu">Title of thu2_chieu</label>
              </span>
            </div>
          </div>
          <div className="col-12 col-sm-1">
            <div className="field">
              <span className="p-float-label p-input-icon-right">
                <i className="pi pi1-envelope" />
                <InputText
                  name="thu3_sang"
                  onChange={(e) => {
                    var filter = {
                      ...aDVSParams,
                      thu3_sang: e.target.value,
                    };
                    setADVSParams(filter);
                    setLazyParams({
                      ...lazyParams,
                      filter: filter,
                    });
                  }}
                  value={aDVSParams.thu3_sang ?? ""}
                />
                <label htmlFor="thu3_sang">Thứ 3</label>
              </span>
            </div>
          </div>
          <div className="col-12 col-sm-2">
            <div className="field">
              <span className="p-float-label p-input-icon-right">
                <i className="pi pi1-envelope" />
                <InputText
                  name="thu3_chieu"
                  onChange={(e) => {
                    var filter = {
                      ...aDVSParams,
                      thu3_chieu: e.target.value,
                    };
                    setADVSParams(filter);
                    setLazyParams({
                      ...lazyParams,
                      filter: filter,
                    });
                  }}
                  value={aDVSParams.thu3_chieu ?? ""}
                />
                <label htmlFor="thu3_chieu">Title of thu3_chieu</label>
              </span>
            </div>
          </div>
          <div className="col-12 col-sm-1">
            <div className="field">
              <span className="p-float-label p-input-icon-right">
                <i className="pi pi1-envelope" />
                <InputText
                  name="thu4_sang"
                  onChange={(e) => {
                    var filter = {
                      ...aDVSParams,
                      thu4_sang: e.target.value,
                    };
                    setADVSParams(filter);
                    setLazyParams({
                      ...lazyParams,
                      filter: filter,
                    });
                  }}
                  value={aDVSParams.thu4_sang ?? ""}
                />
                <label htmlFor="thu4_sang">Thứ 4</label>
              </span>
            </div>
          </div>
          <div className="col-12 col-sm-2">
            <div className="field">
              <span className="p-float-label p-input-icon-right">
                <i className="pi pi1-envelope" />
                <InputText
                  name="thu4_chieu"
                  onChange={(e) => {
                    var filter = {
                      ...aDVSParams,
                      thu4_chieu: e.target.value,
                    };
                    setADVSParams(filter);
                    setLazyParams({
                      ...lazyParams,
                      filter: filter,
                    });
                  }}
                  value={aDVSParams.thu4_chieu ?? ""}
                />
                <label htmlFor="thu4_chieu">Title of thu4_chieu</label>
              </span>
            </div>
          </div>
          <div className="col-12 col-sm-1">
            <div className="field">
              <span className="p-float-label p-input-icon-right">
                <i className="pi pi1-envelope" />
                <InputText
                  name="thu5_sang"
                  onChange={(e) => {
                    var filter = {
                      ...aDVSParams,
                      thu5_sang: e.target.value,
                    };
                    setADVSParams(filter);
                    setLazyParams({
                      ...lazyParams,
                      filter: filter,
                    });
                  }}
                  value={aDVSParams.thu5_sang ?? ""}
                />
                <label htmlFor="thu5_sang">Thứ 5</label>
              </span>
            </div>
          </div>
          <div className="col-12 col-sm-2">
            <div className="field">
              <span className="p-float-label p-input-icon-right">
                <i className="pi pi1-envelope" />
                <InputText
                  name="thu5_chieu"
                  onChange={(e) => {
                    var filter = {
                      ...aDVSParams,
                      thu5_chieu: e.target.value,
                    };
                    setADVSParams(filter);
                    setLazyParams({
                      ...lazyParams,
                      filter: filter,
                    });
                  }}
                  value={aDVSParams.thu5_chieu ?? ""}
                />
                <label htmlFor="thu5_chieu">Title of thu5_chieu</label>
              </span>
            </div>
          </div>
          <div className="col-12 col-sm-1">
            <div className="field">
              <span className="p-float-label p-input-icon-right">
                <i className="pi pi1-envelope" />
                <InputText
                  name="thu6_sang"
                  onChange={(e) => {
                    var filter = {
                      ...aDVSParams,
                      thu6_sang: e.target.value,
                    };
                    setADVSParams(filter);
                    setLazyParams({
                      ...lazyParams,
                      filter: filter,
                    });
                  }}
                  value={aDVSParams.thu6_sang ?? ""}
                />
                <label htmlFor="thu6_sang">Thứ 6</label>
              </span>
            </div>
          </div>
          <div className="col-12 col-sm-2">
            <div className="field">
              <span className="p-float-label p-input-icon-right">
                <i className="pi pi1-envelope" />
                <InputText
                  name="thu6_chieu"
                  onChange={(e) => {
                    var filter = {
                      ...aDVSParams,
                      thu6_chieu: e.target.value,
                    };
                    setADVSParams(filter);
                    setLazyParams({
                      ...lazyParams,
                      filter: filter,
                    });
                  }}
                  value={aDVSParams.thu6_chieu ?? ""}
                />
                <label htmlFor="thu6_chieu">Title of thu6_chieu</label>
              </span>
            </div>
          </div>
          <div className="col-12 col-sm-1">
            <div className="field">
              <span className="p-float-label p-input-icon-right">
                <i className="pi pi1-envelope" />
                <InputText
                  name="thu7_sang"
                  onChange={(e) => {
                    var filter = {
                      ...aDVSParams,
                      thu7_sang: e.target.value,
                    };
                    setADVSParams(filter);
                    setLazyParams({
                      ...lazyParams,
                      filter: filter,
                    });
                  }}
                  value={aDVSParams.thu7_sang ?? ""}
                />
                <label htmlFor="thu7_sang">Thứ 7</label>
              </span>
            </div>
          </div>
          <div className="col-12 col-sm-2">
            <div className="field">
              <span className="p-float-label p-input-icon-right">
                <i className="pi pi1-envelope" />
                <InputText
                  name="thu7_chieu"
                  onChange={(e) => {
                    var filter = {
                      ...aDVSParams,
                      thu7_chieu: e.target.value,
                    };
                    setADVSParams(filter);
                    setLazyParams({
                      ...lazyParams,
                      filter: filter,
                    });
                  }}
                  value={aDVSParams.thu7_chieu ?? ""}
                />
                <label htmlFor="thu7_chieu">Title of thu7_chieu</label>
              </span>
            </div>
          </div>

          <div className="col-12 col-sm-2">
            <Button
              className={"p-button-secondary"}
              icon="pi pi-search"
              label={labelFindButton}
              onClick={() => onFilter()}
            />
            {showAdvancedSearchButton && (
              <Button
                icon={
                  showAdvancedSearch == true
                    ? "fas fa-folder"
                    : "far fa-folder-open"
                }
                className="p-button-outlined p-button-secondary"
                onClick={() => onShowAdvancedSearch()}
                title={labelFind}
                style={{ left: "-3px" }}
              />
            )}
          </div>
        </div>
      )}

      <DataTable
        value={listItems}
        dataKey={fieldID}
        emptyMessage={"Không có kết quả"}
        size="small"
        lazy
        responsiveLayout="stack"
        paginator
        showGridlines
        paginatorTemplate="CurrentPageReport FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink"
        currentPageReportTemplate="{first} - {last} / {totalRecords}"
        paginatorLeft={paginatorLeft}
        totalRecords={totalItems}
        loading={loading}
        rowsPerPageOptions={DEFAULT_LIST_PAGE}
        rows={lazyParams.rows}
        first={lazyParams.first}
        sortField={lazyParams.sortField}
        sortOrder={lazyParams.sortOrder}
        onPage={onPage}
        onSort={onSort}
        onSelectionChange={onSelectionChange}
        selection={selectedItems}
        selectionMode="checkbox"
        headerColumnGroup={headerGroup}
      >
        <Column
          className="text-center"
          style={{ width: "40px" }}
          body={(rowData, item) => {
            return <>{item.rowIndex + 1}</>;
          }}
          header="#"
        />
        <Column
          selectionMode="multiple"
          headerStyle={{ width: "3em" }}
        ></Column>

        <Column
          field="id_nguoi_thuc_hien"
          body={(rowData, column) =>
            decodeUnicode(rowData.ten_id_nguoi_thuc_hien)
          }
        />
        <Column
          field="thu2_sang"
          body={(rowData, column) => decodeUnicode(rowData.thu2_sang)}
        />
        <Column
          field="thu2_chieu"
          body={(rowData, column) => decodeUnicode(rowData.thu2_chieu)}
        />
        <Column
          field="thu3_sang"
          body={(rowData, column) => decodeUnicode(rowData.thu3_sang)}
        />
        <Column
          field="thu3_chieu"
          body={(rowData, column) => decodeUnicode(rowData.thu3_chieu)}
        />
        <Column
          field="thu4_sang"
          body={(rowData, column) => decodeUnicode(rowData.thu4_sang)}
        />
        <Column
          field="thu4_chieu"
          body={(rowData, column) => decodeUnicode(rowData.thu4_chieu)}
        />
        <Column
          field="thu5_sang"
          body={(rowData, column) => decodeUnicode(rowData.thu5_sang)}
        />
        <Column
          field="thu5_chieu"
          body={(rowData, column) => decodeUnicode(rowData.thu5_chieu)}
        />
        <Column
          field="thu6_sang"
          body={(rowData, column) => decodeUnicode(rowData.thu6_sang)}
        />
        <Column
          field="thu6_chieu"
          body={(rowData, column) => decodeUnicode(rowData.thu6_chieu)}
        />
        <Column
          field="thu7_sang"
          body={(rowData, column) => decodeUnicode(rowData.thu7_sang)}
        />
        <Column
          field="thu7_chieu"
          body={(rowData, column) => decodeUnicode(rowData.thu7_chieu)}
        />
        <Column
          field="so_dien_thoai"
          body={(rowData, column) => decodeUnicode(rowData.so_dien_thoai)}
        />
        <Column
          field="link_bao_cao"
          body={(rowData, column) => decodeUnicode(rowData.link_bao_cao)}
        />
        <Column
          style={{ width: "80px" }}
          className={"text-center"}
          body={actionBodyTemplate}
          exportable={false}
        />
      </DataTable>
      <div className="row mb-2">
        <div className="col-12 col-sm-12">
          <Permission code={codePermAdd}></Permission>
          {selectedItems?.length >= 0 ? (
            <Button
              className={
                "p-button-outlined " +
                (selectedItems?.length == 0
                  ? "p-button-secondary p-disabled"
                  : "p-button-danger")
              }
              disabled={selectedItems?.length == 0}
              icon="pi pi-trash"
              label={labelDelete}
              onClick={() => confirmDelete()}
              style={{ marginLeft: "5px" }}
            />
          ) : null}
          <Link to={linkEdit + "/new"}>
            <Button icon="fa fa-plus" label={labelAdd} />
          </Link>
        </div>
      </div>
    </Card>
  );
};
export default GC_LICH_TUANList;