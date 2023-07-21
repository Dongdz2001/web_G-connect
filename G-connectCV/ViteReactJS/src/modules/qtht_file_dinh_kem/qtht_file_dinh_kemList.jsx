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

import qtht_file_dinh_kemFormView from "modules/qtht_file_dinh_kem/qtht_file_dinh_kemFormView";
import qtht_file_dinh_kemForm from "modules/qtht_file_dinh_kem/qtht_file_dinh_kemForm";
import { qtht_file_dinh_kemService } from "modules/qtht_file_dinh_kem/qtht_file_dinh_kemService";

dayjs.extend(utc);
const qtht_file_dinh_kemList = (props) => {
  const { t, i18n } = useTranslation();
  const openDialog = false;
  const fieldID = "id";
  const fieldSort = "id";
  const fieldSortOrder = "ASC";
  const linkEdit = "/admin/qtht_file_dinh_kem-form";
  const linkView = "/admin/qtht_file_dinh_kem-view";
  const showAdvancedSearchButton = true;
  const codePermAdd = "PERM_qtht_file_dinh_kem_ADD";
  const codePermModify = "PERM_qtht_file_dinh_kem_MOD";
  const codePermDel = "PERM_qtht_file_dinh_kem_DEL";
  const deleteMsg = "Bạn có chắc chắn xoá bản ghi này không?";
  const titlePage = "Danh sách Title of qtht_file_dinh_kem";
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
  }, [window.location.href]);
  const loadLazyData = () => {
    setLoading(true);
    console.log(lazyParams);
    let advanceSearch = mapPaginator(lazyParams);
    return qtht_file_dinh_kemService.filterPage(advanceSearch).then((res) => {
      setTotalItems(res.data.meta.total);
      setListItems(res.data.data);
      setLoading(false);
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
    await qtht_file_dinh_kemService.delete(id);
    loadLazyData();
  };
  const deleteItems = async (items) => {
    for (var i = 0; i < items.length; i++) {
      await qtht_file_dinh_kemService.delete(items[i][fieldID]);
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
          <qtht_file_dinh_kemFormView
            id={selectedId}
            fnClose={closeDialog}
          ></qtht_file_dinh_kemFormView>
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
          <qtht_file_dinh_kemForm
            id={selectedId}
            fnClose={closeDialog}
          ></qtht_file_dinh_kemForm>
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
                <InputText
                  name="ten"
                  onChange={(e) => {
                    var filter = {
                      ...aDVSParams,
                      ten: e.target.value,
                    };
                    setADVSParams(filter);
                    setLazyParams({
                      ...lazyParams,
                      filter: filter,
                    });
                  }}
                  value={aDVSParams.ten ?? ""}
                />
                <label htmlFor="ten">Title of ten</label>
              </span>
            </div>
          </div>
          <div className="col-12 col-sm-2">
            <div className="field">
              <span className="p-float-label p-input-icon-right">
                <i className="pi pi1-envelope" />
                <InputText
                  name="duong_dan"
                  onChange={(e) => {
                    var filter = {
                      ...aDVSParams,
                      duong_dan: e.target.value,
                    };
                    setADVSParams(filter);
                    setLazyParams({
                      ...lazyParams,
                      filter: filter,
                    });
                  }}
                  value={aDVSParams.duong_dan ?? ""}
                />
                <label htmlFor="duong_dan">Title of duong_dan</label>
              </span>
            </div>
          </div>
          <div className="col-12 col-sm-2">
            <div className="field">
              <span className="p-float-label p-input-icon-right">
                <i className="pi pi1-envelope" />
                <InputText
                  name="type"
                  onChange={(e) => {
                    var filter = {
                      ...aDVSParams,
                      type: e.target.value,
                    };
                    setADVSParams(filter);
                    setLazyParams({
                      ...lazyParams,
                      filter: filter,
                    });
                  }}
                  value={aDVSParams.type ?? ""}
                />
                <label htmlFor="type">Title of type</label>
              </span>
            </div>
          </div>
          <div className="col-12 col-sm-2">
            <div className="field">
              <span className="p-float-label p-input-icon-right">
                <i className="pi pi1-envelope" />
                <InputText
                  name="noi_dung_tep"
                  onChange={(e) => {
                    var filter = {
                      ...aDVSParams,
                      noi_dung_tep: e.target.value,
                    };
                    setADVSParams(filter);
                    setLazyParams({
                      ...lazyParams,
                      filter: filter,
                    });
                  }}
                  value={aDVSParams.noi_dung_tep ?? ""}
                />
                <label htmlFor="noi_dung_tep">Title of noi_dung_tep</label>
              </span>
            </div>
          </div>
          <div className="col-12 col-sm-2">
            <div className="field">
              <span className="p-float-label p-input-icon-right">
                <i className="pi pi1-envelope" />
                <InputText
                  name="noi_dung_tep_pdf"
                  onChange={(e) => {
                    var filter = {
                      ...aDVSParams,
                      noi_dung_tep_pdf: e.target.value,
                    };
                    setADVSParams(filter);
                    setLazyParams({
                      ...lazyParams,
                      filter: filter,
                    });
                  }}
                  value={aDVSParams.noi_dung_tep_pdf ?? ""}
                />
                <label htmlFor="noi_dung_tep_pdf">
                  Title of noi_dung_tep_pdf
                </label>
              </span>
            </div>
          </div>
          <div className="col-12 col-sm-2">
            <div className="field">
              <span className="p-float-label p-input-icon-right">
                <i className="pi pi1-envelope" />
                <InputText
                  name="file_finish"
                  onChange={(e) => {
                    var filter = {
                      ...aDVSParams,
                      file_finish: e.target.value,
                    };
                    setADVSParams(filter);
                    setLazyParams({
                      ...lazyParams,
                      filter: filter,
                    });
                  }}
                  value={aDVSParams.file_finish ?? ""}
                />
                <label htmlFor="file_finish">Title of file_finish</label>
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
          field="ten"
          sortable
          header={"Title of ten"}
          body={(rowData, column) => decodeUnicode(rowData.ten)}
        />
        <Column
          field="duong_dan"
          sortable
          header={"Title of duong_dan"}
          body={(rowData, column) => decodeUnicode(rowData.duong_dan)}
        />
        <Column
          field="type"
          sortable
          header={"Title of type"}
          body={(rowData, column) => decodeUnicode(rowData.type)}
        />
        <Column
          field="noi_dung_tep"
          sortable
          header={"Title of noi_dung_tep"}
          body={(rowData, column) => decodeUnicode(rowData.noi_dung_tep)}
        />
        <Column
          field="noi_dung_tep_pdf"
          sortable
          header={"Title of noi_dung_tep_pdf"}
          body={(rowData, column) => decodeUnicode(rowData.noi_dung_tep_pdf)}
        />
        <Column
          field="file_finish"
          sortable
          header={"Title of file_finish"}
          body={(rowData, column) => decodeUnicode(rowData.file_finish)}
        />

        <Column
          style={{ width: "80px" }}
          className={"text-center"}
          body={actionBodyTemplate}
          header={<i className="pi pi-cog"></i>}
          exportable={false}
        ></Column>
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
export default qtht_file_dinh_kemList;