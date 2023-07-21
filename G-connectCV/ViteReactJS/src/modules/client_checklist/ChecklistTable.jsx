import React, { useEffect, useState } from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { Link, Outlet, Route, Routes, useParams } from "react-router-dom";
import { t } from "i18next";
import { decodeUnicode } from "shared/utils/decodeHtmlEntites";
import { Button } from "primereact/button";
import { Dropdown } from "primereact/dropdown";
import { DEFAULT_LIST_PARAM, DEFAULT_LIST_PAGE } from "shared/app-settings";
import { useDispatch, useSelector } from "react-redux";
import { Card } from "primereact/card";
import { InputText } from "primereact/inputtext";
import { GC_CONG_VIEC_CHECKLISTService } from "modules/GC_CONG_VIEC_CHECKLIST/GC_CONG_VIEC_CHECKLISTService";
import { mapPaginator } from "shared/utils";
import { Dialog } from "primereact/dialog";
import { setParamState } from "store/listParamSlice";
import { confirmDialogGlobal } from "shared/components/confirmDialogGlobal";
import ChecklistTableForm from "./ChecklistTableForm";
import { Permission } from "components/Permission";
import ChecklistAdd from "./ChecklistAdd";
import { getCurrentUserDefault } from "shared/utils/getCurrentUserDefault";
import { GC_CHUC_NANGService } from "modules/GC_CHUC_NANG/GC_CHUC_NANGService";

export default function ChecklistTable() {
  const fieldID = "id";
  const fieldSort = "id";
  const openDialog = true;
  const fieldSortOrder = "ASC";
  const titlePage = "Danh sách Check-list kiểm thử";
  const labelKeyword = "Từ khoá...";
  const linkEdit = "/admin/GC_CONG_VIEC_CHECKLIST-form";
  const linkEdit1 = "/checklist/ChecklistTableForm";
  const labelAdd = "Thêm check-list";
  const deleteMsg = "Bạn có chắc chắn xoá check-list này không?";
  const labelDelete = "Xóa check-list";
  const codePermAdd = "PERM_GC_CONG_VIEC_CHECKLIST_ADD";
  const [loading, setLoading] = useState(false);
  const [totalItems, setTotalItems] = useState(0);
  const [selectedItems, setSelectedItems] = useState([]);
  const [selectedValueMenu, setSelectedValueMenu] = useState(null);
  const [selectedValueChucNang, setSelectedValueChucNang] = useState(null);
  const [selectedValueCheckList, setSelectedValueCheckList] = useState(null);
  const [aDVSParams, setADVSParams] = useState({});
  const [listItems, setListItems] = useState(null);
  const [searchTerm, setSearchTerm] = useState("");
  const [showMessage, setShowMessage] = useState(false);
  const [selectedId, setSelectedId] = useState(null);
  const [isToggle, setIsToggle] = useState(false);
  const [showDialogEdit, setShowDialogEdit] = useState(false);
  const [showDialogAdd, setShowDialogAdd] = useState(false);
  const [listRef_id_chuc_nang, setListRef_id_chuc_nang] = useState([]);
  const [listRef_id_cong_viec, setListRef_id_cong_viec] = useState([]);
  const [listRef_id_du_an, setListRef_id_du_an] = useState([]);
  const [listRef_id_loai_checklist, setListRef_id_loai_checklist] = useState(
    []
  );
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
  const toggle = () => {
    if (!isToggle) {
      document.body.classList.add("sidebar-collapse");
    } else {
      document.body.classList.remove("sidebar-collapse");
    }
    setIsToggle(!isToggle);
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
  const loadLazyData = () => {
    setLoading(true);
    let advanceSearch = mapPaginator(lazyParams);
    return GC_CONG_VIEC_CHECKLISTService.filterPage(advanceSearch).then(
      (res) => {
        setTotalItems(res.data.meta.total);
        setListItems(res.data.data);
        setLoading(false);
      }
    );
  };
  const deleteItem = async (id) => {
    await GC_CONG_VIEC_CHECKLISTService.delete(id);
    loadLazyData();
  };
  const deleteItems = async (items) => {
    for (var i = 0; i < items.length; i++) {
      await GC_CONG_VIEC_CHECKLISTService.delete(items[i][fieldID]);
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
  const handleSearch = () => {
    const filterdList = listItems.filter((item) => {
      return (
        item.ket_qua_mong_muon
          .toLowerCase()
          .includes(searchTerm.toLowerCase()) ||
        item.ma_cong_viec.toLowerCase().includes(searchTerm.toLowerCase()) ||
        // item.ghi_chu_khac.toLowerCase().includes(searchTerm.toLowerCase()) ||
        item.stt === parseInt(searchTerm) ||
        item.ten_cong_viec.toLowerCase().includes(searchTerm.toLowerCase())
      );
    });
    setListItems(filterdList);
    console.log(filterdList);
  };
  const handleInputChange = (e) => {
    const inputValue = e.target.value;
    setSearchTerm(inputValue);

    if (inputValue === "") {
      loadLazyData();
    }
  };
  useEffect(() => {
    loadLazyData();
  }, [
    lazyParams.refresh,
    selectedValueCheckList,
    selectedValueChucNang,
    selectedValueMenu,
  ]);
  useEffect(() => {
    setTimeout(() => {
      if (listParamStore && listParamStore.pageYOffset)
        window.scrollTo(0, listParamStore.pageYOffset);
    }, 100);
    getListRef_id_du_an();
    getListRef_id_chuc_nang();
    getListRef_id_cong_viec();
    getListRef_id_loai_checklist();
  }, [window.location.href]);

  const columnBodyState = (rowData) => {
    if (rowData) {
      return <i className="pi pi-lock" title={"Bị khoá"}></i>;
    } else return <>Good</>;
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
    return GC_CONG_VIEC_CHECKLISTService.getAllRef_id_chuc_nang().then(
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
    return GC_CONG_VIEC_CHECKLISTService.getAllRef_id_cong_viec().then(
      (res) => {
        res.data.map((x) => {
          x.Value = x.value;
          x.Text = x.label;
        });
        setListRef_id_cong_viec(res.data);
      }
    );
  };
  const getListRef_id_loai_checklist = () => {
    return GC_CONG_VIEC_CHECKLISTService.getAllRef_id_loai_checklist().then(
      (res) => {
        res.data.map((x) => {
          x.Value = x.value;
          x.Text = x.label;
        });
        setListRef_id_loai_checklist(res.data);
      }
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
  const editItem = async (id) => {
    setSelectedId(id);
    dispatch(setParamState({ ...lazyParams, pageYOffset: window.pageYOffset }));
    setShowDialogEdit(true);
    console.log(id);
  };
  const addItem = () => {
    setShowDialogAdd(true);
  };
  const closeDialog = async () => {
    setShowDialogEdit(false);
    setShowDialogAdd(false);
  };
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
      <Dialog showHeader={false} showfooter='false'
        visible={showDialogEdit}
        onHide={() => setShowDialogEdit(false)}
        position="center"
        breakpoints={{ "960px": "80vw" }}
        style={{ width: "40vw" }}
      >
        <div className="flex justify-content-center flex-column">
          <ChecklistTableForm
            id={selectedId}
            fnClose={closeDialog}
            loadLazyData={loadLazyData}
          ></ChecklistTableForm>
        </div>
      </Dialog>

      <Dialog showHeader={false} showfooter='false'
        visible={showDialogAdd}
        onHide={() => setShowDialogAdd(false)}
        position="center"
        breakpoints={{ "960px": "80vw" }}
        style={{ width: "40vw" }}
      >
        <div className="flex justify-content-center flex-column">
          <ChecklistAdd
            fnClose={closeDialog}
            loadLazyData={loadLazyData}
          ></ChecklistAdd>
        </div>
      </Dialog>

      <Card title={titlePage}>
        <div className="row mb-2">
          <div className="row mb-2 advancedSearchBox">
            <div className="col-12 col-sm-2">
              <div className="p-inputgroup" style={{ height: "36.5px" }}>
                <InputText
                  autoFocus
                  placeholder={labelKeyword}
                  value={searchTerm}
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
                                setSelectedValueMenu(selectedOption);
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
                            placeholder={selectedValueMenu ? selectedValueMenu.Text : "--Chọn--"}
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
                      setSelectedValueMenu(selectedOption);
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
                      selectedValueMenu ? selectedValueMenu.Text : "--Chọn--"
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
                      setSelectedValueChucNang(selectedOption);
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
                      selectedValueChucNang
                        ? selectedValueChucNang.Text
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
                    options={listRef_id_loai_checklist}
                    optionValue="Value"
                    optionLabel="Text"
                    scrollHeight={"600px"}
                    className=""
                    value={aDVSParams.id_loai_checklist ?? ""}
                    onChange={(e) => {
                      var selectedOption = listRef_id_loai_checklist.find(
                        (option) => option.Value === e.target.value
                      );
                      setSelectedValueCheckList(selectedOption);
                      var filter = {
                        ...aDVSParams,
                        id_loai_checklist: e.target.value,
                      };
                      setADVSParams(filter);
                      setLazyParams({
                        ...lazyParams,
                        filter: filter,
                      });
                    }}
                    placeholder={
                      selectedValueCheckList
                        ? selectedValueCheckList.Text
                        : "--Chọn--"
                    }
                    showClear
                  />
                  <label htmlFor="id_loai_checklist">Loại checklist</label>
                </span>
              </div>
            </div>
            <div className="col-12 col-sm-3 text-right">
              <Permission code={codePermAdd}></Permission>
              <div>
                <Button
                  icon="fa fa-plus"
                  label={labelAdd}
                  style={{ height: "36px" }}
                  onClick={addItem}
                />
              </div>
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
            selectionMode="multiple"
            headerStyle={{ width: "3em" }}
          ></Column>
          <Column
            field="id_chuc_nang"
            sortable
            style={{ width: "10%" }}
            header={"Chức năng"}
            body={(rowData, column) => decodeUnicode(rowData.ten_id_chuc_nang)}
          />
          <Column
            field="ma_cong_viec"
            sortable
            style={{ width: "5%" }}
            header={"Mã công việc"}
            body={(rowData, column) => decodeUnicode(rowData.ma_cong_viec)}
          />
          <Column
            field="id_cong_viec"
            sortable
            style={{ width: "10%" }}
            header={"Tên công việc"}
            body={(rowData, column) => decodeUnicode(rowData.ten_id_cong_viec)}
          />
          <Column
            field="id_loai_checklist"
            sortable
            style={{ width: "5%" }}
            header={"Loại checklist"}
            body={(rowData, column) =>
              decodeUnicode(rowData.ten_id_loai_checklist)
            }
          />
          <Column
            field="ten_cong_viec"
            sortable
            style={{ width: "20%" }}
            header={"Tên Checklist"}
            body={(rowData, column) => decodeUnicode(rowData.ten_cong_viec)}
          />
          <Column
            field="ket_qua_mong_muon"
            sortable
            style={{ width: "30%" }}
            header={"Kết quả mong muốn"}
            body={(rowData, column) => decodeUnicode(rowData.ket_qua_mong_muon)}
          />
          <Column
            field="ghi_chu_khac"
            sortable
            header={"Ghi chú khác"}
            body={(rowData, column) => decodeUnicode(rowData.ghi_chu_khac)}
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
