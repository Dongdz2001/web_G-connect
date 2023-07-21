import { t } from "i18next";
import { GC_CONG_VIECService } from "modules/GC_CONG_VIEC/GC_CONG_VIECService";
import { Button } from "primereact/button";
import { Card } from "primereact/card";
import { Column } from "primereact/column";
import { DataTable } from "primereact/datatable";
import React, { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import { Link } from "react-router-dom";
import { mapPaginator } from "shared/utils";
import { decodeUnicode } from "shared/utils/decodeHtmlEntites";
import { confirmDialogGlobal } from "shared/components/confirmDialogGlobal";
import { getCurrentUserDefault } from "shared/utils/getCurrentUserDefault";
import { DEFAULT_LIST_PARAM, DEFAULT_LIST_PAGE } from "shared/app-settings";
import { setParamState } from "store/listParamSlice";
import { useSelector } from "react-redux";
import { Dropdown } from "primereact/dropdown";
import Cong_viec_Form from "./Cong_viec_Form";
import { Dialog } from "primereact/dialog";
import { InputText } from "primereact/inputtext";
import { ACTIVE, DEACTIVE } from "shared/utils/appState";
import { InputSwitch } from "primereact/inputswitch";
import { GC_CHUC_NANGService } from "modules/GC_CHUC_NANG/GC_CHUC_NANGService";

export default function cong_viec() {
  const is_super_admin = !getCurrentUserDefault().super_admin;
  const deleteMsg = "Bạn có chắc chắn xoá Công việc này không?";
  const labelDelete = "Xóa Công việc";
  const fieldID = "id";
  const labelAdd = "Thêm Công việc";
  const titlePage = "Danh sách Công việc";
  const fieldSort = "id";
  const fieldSortOrder = "ASC";
  const labelKeyword = "Từ khoá...";
  const dispatch = useDispatch();
  const [listItems, setListItems] = useState(null);
  const [totalItems, setTotalItems] = useState(0);
  const [selectedId, setSelectedId] = useState(null);
  const [showDialogEdit, setShowDialogEdit] = useState(false);
  const [showDialogAdd, setShowDialogAdd] = useState(false);
  const [loading, setLoading] = useState(false);
  const [isToggle, setIsToggle] = useState(false);
  const [searchText, setSearchText] = useState("");
  const [selectedItems, setSelectedItems] = useState([]);
  const [listRef_id_cong_viec_cha, setListRef_id_cong_viec_cha] = useState([]);
  const [listRef_id_chuc_nang, setListRef_id_chuc_nang] = useState([]);
  const [aDVSParams, setADVSParams] = useState({});
  const [valueChucNang, setValueChucNang] = useState(null);
  const [listRef_id_du_an, setListRef_id_du_an] = useState([]);
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
  const [lazyParams, setLazyParams] = useState({
    ...DEFAULT_LIST_PARAM,
    ...{
      sortField: fieldSort,
      sortOrder: fieldSortOrder == "ASC" ? -1 : 1,
    },
    ...listParamStore,
  });
  const loadLazyData = () => {
    setLoading(true);
    let advanceSearch = mapPaginator(lazyParams);
    return GC_CONG_VIECService.filterPage(advanceSearch).then((res) => {
      setTotalItems(res.data.meta.total);
      setListItems(res.data.data);
      setLoading(false);
    });
  };
  const getListRef_id_du_an = () => {
      return GC_CHUC_NANGService.getAllRef_id_du_an().then((res) => {
          res.data.map((x) => {
              x.Value = x.value;
              x.Text = x.label;
          });
          setListRef_id_du_an(res.data);
      });
  };
  const getListRef_id_cong_viec_cha = () => {
    return GC_CONG_VIECService.getAllRef_id_cong_viec_cha().then((res) => {
      res.data.map((x) => {
        x.Value = x.value;
        x.Text = x.label;
      });
      setListRef_id_cong_viec_cha(res.data);
    });
  };
  const getListRef_id_chuc_nang = () => {
    return GC_CONG_VIECService.getAllRef_id_chuc_nang().then((res) => {
      res.data.map((x) => {
        x.Value = x.value;
        x.Text = x.label;
      });
      setListRef_id_chuc_nang(res.data);
    });
  };
  useEffect(() => {
    loadLazyData();
  }, [lazyParams.refresh, valueChucNang]);
  useEffect(() => {
    setTimeout(() => {
      if (listParamStore && listParamStore.pageYOffset)
        window.scrollTo(0, listParamStore.pageYOffset);
    }, 100);
    getListRef_id_du_an();
    getListRef_id_chuc_nang();
    getListRef_id_cong_viec_cha();
  }, [window.location.href]);
  const toggle = () => {
    if (!isToggle) {
      document.body.classList.add("sidebar-collapse");
    } else {
      document.body.classList.remove("sidebar-collapse");
    }
    setIsToggle(!isToggle);
  };
  const editItem = async (id) => {
    setSelectedId(id);
    dispatch(setParamState({ ...lazyParams, pageYOffset: window.pageYOffset }));
    setShowDialogEdit(true);
  };
  const addItem = async (id) => {
      setSelectedId(id);
      setShowDialogEdit(true)
  }
  const deleteItem = async (id) => {
    await GC_CONG_VIECService.delete(id);
    loadLazyData();
  };
  const deleteItems = async (items) => {
    for (var i = 0; i < items.length; i++) {
      await GC_CONG_VIECService.delete(items[i][fieldID]);
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
  const handleInputSearch = (e) => {
    const inputValue = e.target.value;
    setSearchText(inputValue);
    if (inputValue === "") {
      loadLazyData();
    }
  };
  const handleSearch = () => {
    const filteredItems = listItems.filter((item) => {
      return (
        item.stt === parseInt(searchText) ||
        item.ma_cong_viec.toLowerCase().includes(searchText.toLowerCase()) ||
        item.ten_cong_viec.toLowerCase().includes(searchText.toLowerCase()) ||
        // item.noi_dung.toLowerCase().includes(searchText.toLowerCase())
        // item.tham_khao.toLowerCase().includes(searchText.toLowerCase())
        item.so_ngay_estimate === parseInt(searchText)
      );
    });
    setListItems(filteredItems);
  };
  const closeDialog = async () => {
    setShowDialogEdit(false);
    setShowDialogAdd(false);
  };
  const onSelectionChange = (event) => {
    const value = event.value;
    setSelectedItems(value);
  };
  const onPage = (event) => {
    setLazyParams({ ...lazyParams, ...event, refresh: Date.now() });
  };
  const onSort = (event) => {
    setLazyParams({ ...lazyParams, ...event, refresh: Date.now() });
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
          <div onClick={() => editItem(rowData[fieldID])}>
            <i className="p-button-rounded p-button p-button-text p-1 pi pi-pencil mr-2 flex align-items-center"></i>
          </div>
          <a onClick={() => confirmDelete(rowData)}>
            <i className="p-button-rounded p-button p-button-text p-1 pi pi-trash mr-2 flex align-items-center p-button-danger p-button-outlined"></i>
          </a>
        </div>
      </React.Fragment>
    );
  };
  return (
    <div>
      <Dialog
        showHeader={false}
        showFooter={false}
        visible={showDialogEdit}
        onHide={() => setShowDialogEdit(false)}
        position="center"
        breakpoints={{ "960px": "80vw" }}
        style={{ width: "40vw" }}
      >
        <div className="flex justify-content-center flex-column">
          <Cong_viec_Form
            id={selectedId}
            fnClose={closeDialog}
            loadLazyData={loadLazyData}
          ></Cong_viec_Form>
        </div>
      </Dialog>
      <Card title={titlePage}>
        <div className="row mb-2">
          <div className="col-12 col-sm-2">
            <div className="p-inputgroup">
              <InputText
                autoFocus
                placeholder={labelKeyword}
                value={searchText}
                style={{height: '32.5px'}}
                // onKeyDown={onEnterKeySearch}
                onChange={handleInputSearch}
                onKeyUp={handleSearch}
              />
            </div>
          </div>
          <div className="col-12 col-sm-1">
              <div className="field">
                  <span className="p-float-label p-input-icon-right">
                      <i className="pi pi1-envelope" />
                      <Dropdown
                          options={listRef_id_du_an}
                          optionValue="Value"
                          optionLabel="Text"
                          scrollHeight={"600px"}
                          className=""
                          value={aDVSParams.id_du_an ?? ''}
                          onChange={(e) => {
                              var selectedOption = listRef_id_du_an.find(
                              (option) => option.Value === e.target.value
                              );
                              setValueChucNang(selectedOption);
                              var filter = {
                              ...aDVSParams,
                              id_du_an: e.target.value,
                              };
                              setADVSParams(filter);
                              setLazyParams({
                              ...lazyParams,
                              filter: filter,
                              });
                          }}
                          placeholder={valueChucNang ? valueChucNang.Text : "--Chọn--"}
                          showClear
                      />
                      <label htmlFor="id_du_an">Dự án</label>
                  </span>
              </div>
          </div>
          <div className="col-12 col-sm-2">
            <div className="field">
              <span className="p-float-label p-input-icon-right">
                <i className="pi pi1-envelope" />
                <Dropdown
                  options={listRef_id_chuc_nang.filter(x=>x.id_du_an==aDVSParams.id_du_an || aDVSParams.id_du_an==null)}
                  optionValue="Value"
                  optionLabel="Text"
                  scrollHeight={"600px"}
                  className=""
                  value={aDVSParams.id_chuc_nang ?? ""}
                  onChange={(e) => {
                    var selectedOption = listRef_id_chuc_nang.find(
                      (option) => option.Value === e.target.value
                    );
                    setValueChucNang(selectedOption);
                    var filter = {
                      ...aDVSParams,
                      id_chuc_nang: e.target.value,
                    };
                    setADVSParams(filter);
                    setLazyParams({
                      ...lazyParams,
                      filter: filter,
                    });
                  }}
                  placeholder={valueChucNang ? valueChucNang.Text : "--Chọn--"}
                  showClear
                />
                <label htmlFor="id_chuc_nang">Chức năng</label>
              </span>
            </div>
          </div>
          <div className="col-12 col-sm-2">
            <div className="field">
              <span className="p-float-label p-input-icon-right">
                <i className="pi pi1-envelope" />
                <Dropdown
                  options={listRef_id_cong_viec_cha.filter(x=>(x.id_du_an==aDVSParams.id_du_an || aDVSParams.id_du_an==null) && (x.id_chuc_nang==aDVSParams.id_du_an || aDVSParams.id_chuc_nang==null))}
                  optionValue="Value"
                  optionLabel="Text"
                  scrollHeight={"600px"}
                  className=""
                  value={aDVSParams.id_cong_viec_cha ?? ""}
                  onChange={(e) => {
                    var selectedOption = listRef_id_cong_viec_cha.find(
                      (option) => option.Value === e.target.value
                    );
                    setValueChucNang(selectedOption);
                    var filter = {
                      ...aDVSParams,
                      id_cong_viec_cha: e.target.value,
                    };
                    setADVSParams(filter);
                    setLazyParams({
                      ...lazyParams,
                      filter: filter,
                    });
                  }}
                  placeholder={valueChucNang ? valueChucNang.Text : "--Chọn--"}
                  showClear
                />
                <label htmlFor="id_cong_viec_cha">Công việc cha</label>
              </span>
            </div>
          </div>
          <div className="col-12 col-sm-5 text-right">
            <div>
              {is_super_admin && <Button onClick={() => addItem(null)} icon="fa fa-plus" label={labelAdd} ></Button>}
            </div>
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
            field="id_chuc_nang"
            sortable
            header={"Chức năng"}
            body={(rowData, column) => decodeUnicode(rowData.ten_id_chuc_nang)}
          />
          <Column
            field="ma_cong_viec"
            sortable
            header={"Mã công việc"}
            body={(rowData, column) => decodeUnicode(rowData.ma_cong_viec)}
          />
          <Column
            field="ten_cong_viec"
            sortable
            header={"Tên công việc"}
            body={(rowData, column) => <>
                {rowData.ten_id_cong_viec_cha ? '<b>' + decodeUnicode(rowData.ten_id_cong_viec_cha) + '</b><br>' : ''}
                {decodeUnicode(rowData.ten_cong_viec)}
              </>}
          />
          <Column
            field="is_cong_viec_nhom"
            sortable
            header={"Trạng thái"}
            body={(rowData, column) => <>
              <div className="field">
                <span className="p-float-label p-input-icon-right">
                    <InputSwitch 
                        name="is_cong_viec_nhom" trueValue={ACTIVE} falseValue={DEACTIVE} 
                        checked={rowData.is_cong_viec_nhom} />
                    <label htmlFor="is_cong_viec_nhom">Là công việc nhóm</label>
                </span>
              </div>
              <div className="field">
                <span className="p-float-label p-input-icon-right">
                    <InputSwitch 
                        name="is_da_code" trueValue={ACTIVE} falseValue={DEACTIVE} 
                        checked={rowData.is_da_code} />
                    <label htmlFor="is_da_code">Đã code</label>
                </span>
              </div>
              <div className="field">
                <span className="p-float-label p-input-icon-right">
                    <InputSwitch 
                        name="is_da_test" trueValue={ACTIVE} falseValue={DEACTIVE} 
                        checked={rowData.is_da_test} />
                    <label htmlFor="is_da_test">Đã test</label>
                </span>
              </div>
              </>}
          />
          <Column
            field="noi_dung"
            sortable
            header={"Nội dung"}
            body={(rowData, column) => decodeUnicode(rowData.noi_dung)}
          />
          <Column
            field="tham_khao"
            sortable
            header={"Tham khảo"}
            body={(rowData, column) => decodeUnicode(rowData.tham_khao)}
          />
          <Column
            field="so_ngay_estimate"
            sortable
            header={"Số ngày dự kiến"}
            body={(rowData, column) => decodeUnicode(rowData.so_ngay_estimate)}
          />

          <Column
            style={{ width: "80px" }}
            className={"text-center"}
            body={actionBodyTemplate}
            header={<i className="pi pi-cog"></i>}
            exportable={false}
          ></Column>
        </DataTable>
      </Card>
    </div>
  );
}
