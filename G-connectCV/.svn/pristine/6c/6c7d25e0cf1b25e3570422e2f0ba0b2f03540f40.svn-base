import dayjs from "dayjs";
import utc from "dayjs/plugin/utc";
import { t } from "i18next";
import { GC_CONG_VIEC_PHAN_CONGService } from "modules/GC_CONG_VIEC_PHAN_CONG/GC_CONG_VIEC_PHAN_CONGService";
import { Button } from "primereact/button";
import { Card } from "primereact/card";
import { Column } from "primereact/column";
import { DataTable } from "primereact/datatable";
import { Dropdown } from "primereact/dropdown";
import { InputText } from "primereact/inputtext";
import React, { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { Link } from "react-router-dom";
import { DEFAULT_LIST_PAGE, DEFAULT_LIST_PARAM } from "shared/app-settings";
import { mapPaginator } from "shared/utils";
import { decodeUnicode } from "shared/utils/decodeHtmlEntites";
import Cong_Viec_Phan_Cong_Form from "./Cong_Viec_Phan_Cong_Form";
import { useDispatch } from "react-redux";
import { setParamState } from "store/listParamSlice";
import { Dialog } from "primereact/dialog";
import { confirmDialogGlobal } from "shared/components/confirmDialogGlobal";
import { getCurrentUserDefault } from "shared/utils/getCurrentUserDefault";
import { GC_CHUC_NANGService } from "modules/GC_CHUC_NANG/GC_CHUC_NANGService";

dayjs.extend(utc);
export default function Cong_Viec_Phan_Cong() {
  const titlePage = "Danh sách Phân công Công việc";
  const fieldID = "id";
  const fieldSort = "stt";
  const fieldSortOrder = "ASC";
  const openDialog = false;
  const linkEdit = "/admin/GC_CONG_VIEC_PHAN_CONG-form";
  const linkView = "/admin/GC_CONG_VIEC_PHAN_CONG-view";
  const labelKeyword = "Từ khoá...";
  const labelFind = "Tìm kiếm nâng cao";
  const labelAdd = "Thêm phân công";
  const labelDelete = "Xóa phân công";
  const deleteMsg = "Bạn có chắc chắn xoá phân công này không?";
  const is_super_admin = !getCurrentUserDefault().super_admin;
  const showAdvancedSearchButton = true;
  const [isToggle, setIsToggle] = useState(false);
  const [listItems, setListItems] = useState(null);
  const [totalItems, setTotalItems] = useState(0);
  const [loading, setLoading] = useState(false);
  const [selectedItems, setSelectedItems] = useState([]);
  const [showDialogEdit, setShowDialogEdit] = useState(false);
  const [showDialogAdd, setShowDialogAdd] = useState(false);
  const [selectedId, setSelectedId] = useState(null);
  const [selectedValueChucNang, setSelectedValueChucNang] = useState(null);
  const [selectedValueCongViec, setSelectedValueCongViec] = useState(null);
  const [selectedValueThucHien, setSelectedValueThucHien] = useState(null);
  const [showAdvancedSearch, setShowAdvancedSearch] = useState(false);
  const [searchText, setSearchText] = useState("");
  const [listRef_id_chuc_nang, setListRef_id_chuc_nang] = useState([]);
  const [listRef_id_cong_viec, setListRef_id_cong_viec] = useState([]);
  const [listRef_id_trang_thai, setListRef_id_trang_thai] = useState([]);
  const [listRef_id_du_an, setListRef_id_du_an] = useState([]);
  const [listRef_id_nguoi_thuc_hien, setListRef_id_nguoi_thuc_hien] = useState(
    []
  );
  const [listRef_id_nguoi_phoi_hop, setListRef_id_nguoi_phoi_hop] = useState(
    []
  );
  const [listRef_id_nguoi_duyet, setListRef_id_nguoi_duyet] = useState([]);
  const [aDVSParams, setADVSParams] = useState({});
  const dispatch = useDispatch();
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
    console.log(lazyParams);
    let advanceSearch = mapPaginator(lazyParams);
    return GC_CONG_VIEC_PHAN_CONGService.filterPage(advanceSearch).then(
      (res) => {
        setTotalItems(res.data.meta.total);
        setListItems(res.data.data);
        setLoading(false);
      }
    );
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
  const getListRef_id_chuc_nang = () => {
    return GC_CONG_VIEC_PHAN_CONGService.getAllRef_id_chuc_nang().then(
      (res) => {
        res.data.map((x) => {
          x.Value = x.value;
          x.Text = x.label;
        });
        setListRef_id_chuc_nang(res.data);
      }
    );
  };
  const getListRef_id_cong_viec = () => {
    return GC_CONG_VIEC_PHAN_CONGService.getAllRef_id_cong_viec().then(
      (res) => {
        res.data.map((x) => {
          x.Value = x.value;
          x.Text = x.label;
        });
        setListRef_id_cong_viec(res.data);
      }
    );
  };
  const getListRef_id_trang_thai = () => {
    return GC_CONG_VIEC_PHAN_CONGService.getAllRef_id_trang_thai().then(
      (res) => {
        res.data.map((x) => {
          x.Value = x.value;
          x.Text = x.label;
        });
        setListRef_id_trang_thai(res.data);
      }
    );
  };
  const getListRef_id_nguoi_thuc_hien = () => {
    return GC_CONG_VIEC_PHAN_CONGService.getAllRef_id_nguoi_thuc_hien().then(
      (res) => {
        res.data.map((x) => {
          x.Value = x.value;
          x.Text = x.label;
        });
        setListRef_id_nguoi_thuc_hien(res.data);
      }
    );
  };
  const getListRef_id_nguoi_phoi_hop = () => {
    return GC_CONG_VIEC_PHAN_CONGService.getAllRef_id_nguoi_phoi_hop().then(
      (res) => {
        res.data.map((x) => {
          x.Value = x.value;
          x.Text = x.label;
        });
        setListRef_id_nguoi_phoi_hop(res.data);
      }
    );
  };
  const getListRef_id_nguoi_duyet = () => {
    return GC_CONG_VIEC_PHAN_CONGService.getAllRef_id_nguoi_duyet().then(
      (res) => {
        res.data.map((x) => {
          x.Value = x.value;
          x.Text = x.label;
        });
        setListRef_id_nguoi_duyet(res.data);
      }
    );
  };
  const onPage = (event) => {
    setLazyParams({ ...lazyParams, ...event, refresh: Date.now() });
  };
  const onSort = (event) => {
    setLazyParams({ ...lazyParams, ...event, refresh: Date.now() });
  };
  const onSelectionChange = (event) => {
    const value = event.value;
    setSelectedItems(value);
  };
  const onFilter = (event) => {
    setLazyParams({ ...lazyParams, page: 0, first: 0, refresh: Date.now() });
  };
  const onEnterKeySearch = (event) => {
    if (event.key === "Enter") {
      onFilter();
    }
  }; 
  const handleInputChange = (event) => {
    const inputValue = event.target.value;
    setSearchText(inputValue);
    if(inputValue === ""){
      loadLazyData()
    }
  }
  const handleSearch = () => {
    const filterdList = listItems.filter((item) => {
      return (
        item.stt === parseInt(searchText) ||
        item.noi_dung.toLowerCase().includes(searchText.toLowerCase()) ||
        item.ten_cong_viec.toLowerCase().includes(searchText.toLowerCase()) ||
        item.dac_ta.toLowerCase().includes(searchText.toLowerCase()) ||
        item.ma_cong_viec.toLowerCase().includes(searchText.toLowerCase())
        // item.tra_loi.toLowerCase().includes(searchText.toLowerCase()) ||
        // item.log_review.toLowerCase().includes(searchText.toLowerCase())
        // item.tham_khao.toLowerCase().includes(searchText.toLowerCase())
      )
    })
    setListItems(filterdList)
  }
  const closeDialog = async () => {
    setShowDialogEdit(false);
    setShowDialogAdd(false);
  };
  const editItem = async (id) => {
    setSelectedId(id);
    dispatch(setParamState({ ...lazyParams, pageYOffset: window.pageYOffset }));
    setShowDialogEdit(true);
  };
  const addItem = () => {
    setSelectedId('new');
    setShowDialogEdit(true);
  };
  const deleteItem = async (id) => {
    await GC_CONG_VIEC_PHAN_CONGService.delete(id);
    loadLazyData();
  };
  const deleteItems = async (items) => {
    for (var i = 0; i < items.length; i++) {
      await GC_CONG_VIEC_PHAN_CONGService.delete(items[i][fieldID]);
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
  useEffect(() => {
    loadLazyData();
  }, [
    lazyParams.refresh,
    selectedValueChucNang,
    selectedValueCongViec,
    selectedValueThucHien,
  ]);
  useEffect(() => {
    setTimeout(() => {
      if (listParamStore && listParamStore.pageYOffset)
        window.scrollTo(0, listParamStore.pageYOffset);
    }, 100);
    getListRef_id_du_an();
    getListRef_id_chuc_nang();
    getListRef_id_cong_viec();
    getListRef_id_trang_thai();
    getListRef_id_nguoi_thuc_hien();
    getListRef_id_nguoi_phoi_hop();
    getListRef_id_nguoi_duyet();
  }, [window.location.href]);
  const toggle = () => {
    if (!isToggle) {
      document.body.classList.add("sidebar-collapse");
    } else {
      document.body.classList.remove("sidebar-collapse");
    }
    setIsToggle(!isToggle);
  };
  const columnBodyDate = (date) => {
    return dayjs(date).format("DD/MM/YYYY HH:mm");
  };
  const actionBodyTemplate = (rowData) => {
    return (
      <React.Fragment>
        <div className="flex flex-row justify-content-end">
          {is_super_admin && <div onClick={() => editItem(rowData[fieldID])}>
            <i className="p-button-rounded p-button p-button-text p-1 pi pi-pencil mr-2 flex align-items-center"></i>
          </div>}
          {is_super_admin && <a onClick={() => confirmDelete(rowData)}>
            <i className="p-button-rounded p-button p-button-text p-1 pi pi-trash mr-2 flex align-items-center p-button-danger p-button-outlined"></i>
          </a>}
        </div>
      </React.Fragment>
    );
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
    <Card title={titlePage}>
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
          <Cong_Viec_Phan_Cong_Form
            id={selectedId}
            fnClose={closeDialog}
            loadLazyData={loadLazyData}
          ></Cong_Viec_Phan_Cong_Form>
        </div>
      </Dialog>

      <div className="row mb-2">
        <div className="col-12 col-sm-2">
          <div className="p-inputgroup">
            <InputText
              autoFocus
              style={{height: '32.5px'}}
              placeholder={labelKeyword}
              value={searchText}
              onKeyDown={onEnterKeySearch}
              onChange={handleInputChange}
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
                            setSelectedValueChucNang(selectedOption);
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
                        placeholder={selectedValueChucNang ? selectedValueChucNang.Text : "--Chọn--"}
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
                options={listRef_id_chuc_nang.filter(x=>(x.id_du_an==aDVSParams.id_du_an || aDVSParams.id_du_an==null))}
                optionValue="Value"
                optionLabel="Text"
                scrollHeight={"600px"}
                className=""
                value={aDVSParams.id_chuc_nang ?? ""}
                onChange={(e) => {
                  var selectedOption = listRef_id_chuc_nang.find(
                    (option) => option.Value === e.target.value
                  );
                  setSelectedValueChucNang(selectedOption);
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
                placeholder={
                  selectedValueChucNang
                    ? selectedValueChucNang.Text
                    : "--Chọn--"
                }
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
                options={listRef_id_cong_viec.filter(x=>(x.id_du_an==aDVSParams.id_du_an || aDVSParams.id_du_an==null) && (x.id_chuc_nang==aDVSParams.id_du_an || aDVSParams.id_chuc_nang==null))}
                optionValue="Value"
                optionLabel="Text"
                scrollHeight={"600px"}
                className=""
                value={aDVSParams.id_cong_viec ?? ""}
                onChange={(e) => {
                  var selectedOption = listRef_id_cong_viec.find(
                    (option) => option.Value === e.target.value
                  );
                  setSelectedValueCongViec(selectedOption);
                  var filter = {
                    ...aDVSParams,
                    id_cong_viec: e.target.value,
                  };
                  setADVSParams(filter);
                  setLazyParams({
                    ...lazyParams,
                    filter: filter,
                  });
                }}
                placeholder={
                  selectedValueCongViec
                    ? selectedValueCongViec.Text
                    : "--Chọn--"
                }
                showClear
              />
              <label htmlFor="id_cong_viec">Công việc</label>
            </span>
          </div>
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
                value={aDVSParams.id_nguoi_thuc_hien ?? ""}
                onChange={(e) => {
                  var selectedOption = listRef_id_nguoi_thuc_hien.find(
                    (option) => option.Value === e.target.value
                  );
                  setSelectedValueThucHien(selectedOption);
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
                placeholder={
                  selectedValueThucHien
                    ? selectedValueThucHien.Text
                    : "--Chọn--"
                }
                showClear
              />
              <label htmlFor="id_nguoi_thuc_hien">Phân công</label>
            </span>
          </div>
        </div>
        <div className="col-12 col-sm-3 text-right">
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
          header={"Menu"}
          body={(rowData, column) => decodeUnicode(rowData.ten_id_chuc_nang)}
        />
        <Column
          field="ma_cong_viec"
          sortable
          header={"Mã CN"}
          body={(rowData, column) => decodeUnicode(rowData.ma_cong_viec)}
        />
        <Column
          field="id_cong_viec"
          sortable
          header={"Tên chức năng"}
          body={(rowData, column) => decodeUnicode(rowData.ten_id_cong_viec)}
        />
        <Column
          field="noi_dung"
          sortable
          header={"Tác nhân"}
          body={(rowData, column) => decodeUnicode(rowData.noi_dung)}
        />
        <Column
          field="ten_cong_viec"
          sortable
          header={"Mô tả"}
          body={(rowData, column) => decodeUnicode(rowData.ten_cong_viec)}
        />
        <Column
          field="tra_loi"
          sortable
          header={"Sẵn sàng cho Dev"}
          body={(rowData, column) => decodeUnicode(rowData.tra_loi)}
        />
        <Column
          field="id_nguoi_thuc_hien"
          sortable
          header={"Phân công"}
          body={(rowData, column) =>
            decodeUnicode(rowData.ten_id_nguoi_thuc_hien)
          }
        />
        <Column
          field="dac_ta"
          sortable
          header={"Đặc tả"}
          body={(rowData, column) => decodeUnicode(rowData.dac_ta)}
        />
        <Column
          field="so_ngay_estimate"
          sortable
          header={"Estimate giờ công"}
          body={(rowData, column) => decodeUnicode(rowData.so_ngay_estimate)}
        />
        <Column
          style={{ width: "200px" }}
          className={"text-center"}
          field="ngay_ket_thuc"
          body={(rowData, column) => columnBodyDate(rowData.ngay_ket_thuc)}
          header={"Ngày kết thúc"}
        />
        <Column
          field="is_da_duyet"
          sortable
          header={"Status"}
          body={(rowData, column) => decodeUnicode(rowData.is_da_duyet)}
        />
        <Column
          field="log_review"
          sortable
          header={"Estimate API"}
          body={(rowData, column) => decodeUnicode(rowData.log_review)}
        />
        <Column
          field="tham_khao"
          sortable
          header={"Ghi chú coding"}
          body={(rowData, column) => decodeUnicode(rowData.tham_khao)}
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
  );
}
