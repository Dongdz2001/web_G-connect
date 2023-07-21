import React, { useState, useEffect, useRef } from "react";
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
import { getCurrentUserDefault } from 'shared/utils/getCurrentUserDefault';

import GC_DU_ANFormView from "modules/GC_DU_AN/GC_DU_ANFormView";
import GC_DU_ANForm from "modules/GC_DU_AN/GC_DU_ANForm";
import { GC_DU_ANService } from "modules/GC_DU_AN/GC_DU_ANService";
import DuanForm from "./DuanForm";

dayjs.extend(utc);

const DuanList = () => {
  const { t, i18n } = useTranslation();
  const openDialog = !false;
  const fieldID = "id";
  const fieldSort = "id";
  const fieldSortOrder = "ASC";
  const linkEdit = "/Duans/Duan-form";
  const showAdvancedSearchButton = true;
  const codePermAdd = "PERM_GC_DU_AN_ADD";
  const codePermModify = "PERM_GC_DU_AN_MOD";
  const codePermDel = "PERM_GC_DU_AN_DEL";
  const deleteMsg = "Bạn có chắc chắn xoá dự án này không?";
  const titlePage = "Danh sách Dự án";
  const labelAdd = "Thêm dự án";
  const labelDelete = "Xóa dự án";
  const labelKeyword = "Từ khoá...";
  const labelFind = "Tìm kiếm nâng cao";
  const labelFindButton = "Tìm kiếm";

  const columnBodyDate = (date) => {
    return dayjs(date).format('DD/MM/YYYY ')
    // return dayjs.utc(date).utcOffset(420).format("DD/MM/YYYY HH:mm");

  };

  /**/
  /**/
  const dispatch = useDispatch();
  const is_super_admin = getCurrentUserDefault().super_admin;
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

  const [selectedValue, setSelectedValue] = useState(null);

  const [listRef_id_loai_du_an, setListRef_id_loai_du_an] = useState([]);
  const [listTinhTrang, setListTinhTrang] = useState([{'Value': 1, 'Text': 'Đang triển khai'}, {'Value': 2, 'Text': 'Đã đóng'}]);    
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
  }, [lazyParams.refresh, selectedValue]);
  useEffect(() => {
    setTimeout(() => {
      if (listParamStore && listParamStore.pageYOffset)
        window.scrollTo(0, listParamStore.pageYOffset);
    }, 100);

    getListRef_id_loai_du_an();
  }, [window.location.href]);
  const loadLazyData = () => {
    setLoading(true);
    let advanceSearch = mapPaginator(lazyParams);
    return GC_DU_ANService.filterPage(advanceSearch).then((res) => {
      setTotalItems(res.data.meta.total);
      setListItems(res.data.data);
      setLoading(false);
    });
  };

  const getListRef_id_loai_du_an = () => {
    return GC_DU_ANService.getAllRef_id_loai_du_an().then((res) => {
      res.data.map((x) => {
        x.Value = x.value;
        x.Text = x.label;
      });
      setListRef_id_loai_du_an(res.data);
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

  const editItem = async (id) => {
    setSelectedId(id);
    dispatch(setParamState({ ...lazyParams, pageYOffset: window.pageYOffset }));
    setShowDialogEdit(true);
  }
  const addItem = async (id) => {
      setSelectedId(id);
      setShowDialogEdit(true)
  }
  const closeDialog = async () => {
    setShowDialogEdit(false);
    setShowDialogView(false);
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

  return (
    <div className="text-center-">
      <Card title={titlePage}>
        <Toast ref={toast} />

        <Dialog
          visible={showDialogEdit} showHeader={false} showfooter='false'
          onHide={() => setShowDialogEdit(false)}
          position="center"
          style={{ width: "40vw" }}
        >
          <div className="flex justify-content-center flex-column pt-6 px-3">
            <DuanForm id={selectedId} fnClose={closeDialog} loadLazyData={loadLazyData}></DuanForm>
          </div>
        </Dialog>
        <div className="row mb-2">
          <div className="col-12 col-sm-2">
            <div className="p-inputgroup">
              <InputText
                autoFocus
                placeholder={labelKeyword}
                onKeyDown={onEnterKeySearch}
                onChange={(e) => onChangeKeySearch(e.target.value)}
                value={aDVSParams.keySearch ?? ""}
              />
              {/* <Button
              icon="pi pi-search"
              className="p-button-outlined p-button-secondary"
              onClick={() => onFilter()}
            /> */}

            </div>
          </div>
          <div className="col-12 col-sm-1">
              <div className="field">
                  <span className="p-float-label p-input-icon-right">
                      <i className="pi pi1-envelope" />
                      <Dropdown
                          options={listTinhTrang}
                          optionValue="Value"
                          optionLabel="Text"
                          scrollHeight={"600px"}
                          className=""
                          value={aDVSParams.is_da_dong ?? ''}
                          onChange={(e) => {
                              var selectedOption = listTinhTrang.find(
                                  (option) => option.Value === e.target.value
                              );
                              setSelectedValue(selectedOption);
                              var filter = {
                                  ...aDVSParams,
                                  is_da_dong: e.target.value,
                              };
                              setADVSParams(filter);
                              setLazyParams({
                                  ...lazyParams,
                                  filter: filter,
                              });
                          }}
                          placeholder={selectedValue ? selectedValue.Text : "--Chọn--"}
                          showClear
                      />
                      <label htmlFor="is_da_dong">Tình trạng</label>
                  </span>
              </div>
          </div>

          <div className="col-12 col-sm-1">
            <div className="field">
              <span className="p-float-label p-input-icon-right">
                <i className="pi pi1-envelope" />
                <Dropdown
                  options={listRef_id_loai_du_an}
                  optionValue="Value"
                  optionLabel="Text"
                  scrollHeight={"600px"}
                  className=""
                  value={aDVSParams.id_loai_du_an ?? ''}
                  onChange={(e) => {
                    var selectedOption = listRef_id_loai_du_an.find(
                      (option) => option.Value === e.target.value
                    );
                    setSelectedValue(selectedOption);
                    var filter = {
                      ...aDVSParams,
                      id_loai_du_an: e.target.value,
                    };
                    setADVSParams(filter);
                    setLazyParams({
                      ...lazyParams,
                      filter: filter,
                    });
                  }}
                  placeholder={selectedValue ? selectedValue.Text : "--Chọn--"}
                  showClear
                />
                <label htmlFor="id_loai_du_an">Loại dự án</label>
              </span>
            </div>
          </div>
          <div className="col-12 col-sm-4 text-right">
            <Permission code={codePermAdd}></Permission>
            {is_super_admin && <Button onClick={() => addItem(null)} icon="fa fa-plus" label={labelAdd} ></Button>}
          </div>
        </div>



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
            className="text-center"
            field="id_loai_du_an"
            sortable
            header={"Loại dự án"}
            body={(rowData, column) => decodeUnicode(rowData.ten_id_loai_du_an)}
          />
          <Column
            className="text-center"
            field="ten_du_an"
            sortable
            header={"Tên dự án"}
            body={(rowData, column) => decodeUnicode(rowData.ten_du_an)}
          />
          <Column
            className="text-center"
            field="is_da_dong"
            sortable
            header={"Đã đóng"}
            body={(rowData, column) => (
              <div style={{
                color: rowData.is_da_dong ? "blue" : "red",
                textAlign: 'center'
              }} >
                {rowData.is_da_dong ? "Đã đóng" : "Đang triển khai"}
              </div>
            )}
          />
          <Column
            style={{ width: "140px" }}
            className={"text-center"}
            field="ngay_bat_dau"
            body={(rowData, column) => columnBodyDate(rowData.ngay_bat_dau)}
            header={"Ngày bắt đầu"}
          />
          <Column
            style={{ width: "140px" }}
            className={"text-center"}
            field="ngay_ket_thuc"
            body={(rowData, column) => columnBodyDate(rowData.ngay_ket_thuc)}
            header={"Ngày kết thúc"}
          />
          <Column
            field="thong_tin_khach_hang"
            sortable
            header={"Thông tin khách hàng"}
            body={(rowData, column) =>
              decodeUnicode(rowData.thong_tin_khach_hang.replace(/<\/?p[^>]*>/g, '').replace(/"/g, '""'))
            }
          />
          <Column
            className={"text-center"}
            body={(rowData) => {
              return (
                <div className="flex flex-row justify-content-center">
                  {is_super_admin && <div
                    onClick={() => editItem(rowData[fieldID])}
                  >
                    <i className="p-button-rounded p-button p-button-text p-1 pi pi-pencil  flex align-items-center"></i>
                  </div>}

                </div>
              )
            }}
            header={<i className="pi pi-cog"></i>}
            exportable={false}
          ></Column>
        </DataTable>

      </Card>
    </div>
  )
}

export default DuanList
