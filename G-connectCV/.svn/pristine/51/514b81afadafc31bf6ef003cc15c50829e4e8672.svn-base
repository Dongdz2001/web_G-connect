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

import CLIENT_LICH_TUANForm from "modules/CLIENT_LICH_TUAN/CLIENT_LICH_TUANForm";
import { GC_LICH_TUANService } from "modules/GC_LICH_TUAN/GC_LICH_TUANService";
import { ColumnGroup } from "primereact/columngroup";
import { Row } from "primereact/row";

import * as XLSX from "xlsx/xlsx.mjs";
import { getCurrentUserDefault } from "shared/utils/getCurrentUserDefault";

dayjs.extend(utc);
const CLIENT_LICH_TUANList = (props) => {
  const { t, i18n } = useTranslation();
  const id = getCurrentUserDefault().id;
  const is_super_admin = getCurrentUserDefault().super_admin;
  const openDialog = true;
  const fieldID = "id";
  const fieldSort = "id";
  const fieldSortOrder = "ASC";
  const linkEdit = "/client/lich-tuan-form";
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
  const itemService = GC_LICH_TUANService;
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
  const actionBodyTemplate = (rowData, column, value, width = "50px") => {
    const [inputValue, setInputValue] = useState(value);

    const handleChange = (e) => {
      setInputValue(e.target.value);
    };
    const handleBlur = async () => {
      if (column.field == "thu2_sang") {
        rowData.thu2_sang = inputValue;
      }
      if (column.field == "thu2_chieu") {
        rowData.thu2_chieu = inputValue;
      }
      if (column.field == "thu3_sang") {
        rowData.thu3_sang = inputValue;
      }
      if (column.field == "thu3_chieu") {
        rowData.thu3_chieu = inputValue;
      }
      if (column.field == "thu4_sang") {
        rowData.thu4_sang = inputValue;
      }
      if (column.field == "thu4_chieu") {
        rowData.thu4_chieu = inputValue;
      }
      if (column.field == "thu5_sang") {
        rowData.thu5_sang = inputValue;
      }
      if (column.field == "thu5_chieu") {
        rowData.thu5_chieu = inputValue;
      }
      if (column.field == "thu6_sang") {
        rowData.thu6_sang = inputValue;
      }
      if (column.field == "thu6_chieu") {
        rowData.thu6_chieu = inputValue;
      }
      if (column.field == "thu7_sang") {
        rowData.thu7_sang = inputValue;
      }
      if (column.field == "thu7_chieu") {
        rowData.thu7_chieu = inputValue;
      }
      if (column.field == "so_dien_thoai") {
        rowData.so_dien_thoai = inputValue;
        rowData.qtht_nguoi_dung_id_nguoi_thuc_hien.so_dien_thoai = inputValue;
      }
      if (column.field == "link_bao_cao") {
        rowData.link_bao_cao = inputValue;
        rowData.qtht_nguoi_dung_id_nguoi_thuc_hien.anh_dai_dien_url =
          inputValue;
      }

      await itemService.update(rowData.id, rowData);
    };
    return (
      <InputText
        value={inputValue ?? ""}
        onBlur={handleBlur}
        onChange={handleChange}
        style={{ width: width }}
        className="input-center"
      />
    );
  };
  const headerGroup = (
    <ColumnGroup>
      <Row>
        <Column className="text-center" rowSpan={2} header="TT" />
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
        </div>
      </Dialog>
      <Dialog
        visible={showDialogEdit}
        onHide={() => setShowDialogEdit(false)}
        position="center"
        showHeader={false}
        showfooter='false'
        breakpoints={{ "660px": "80vw" }}
        style={{ width: "500px" }}
      >
        <div className="flex justify-content-center flex-column pt-6 px-3">
          <CLIENT_LICH_TUANForm
            id={selectedId}
            items={listItems}
            fnClose={closeDialog}
            fnLoadData={loadLazyData}
          ></CLIENT_LICH_TUANForm>
        </div>
      </Dialog>
      <div style={{color: 'red', fontStyle: 'italic', fontWeight: 'bold'}}>
        (Nhân viên cập nhật cho tuần tiếp theo vào thứ 6 - 7 hàng tuần, đánh X vào các ngày có kế hoạch đi làm)<br/>
        <br/>
        Tạo google-doc của mình ghi vào ô Link báo cáo để báo cáo công việc hàng ngày<br/>
        Tạo header trang có tên người báo cáo
      </div>
      <DataTable
        value={listItems}
        dataKey={fieldID}
        emptyMessage={"Không có kết quả"}
        size="small"
        lazy
        responsiveLayout="stack"
        showGridlines
        paginatorTemplate=""
        currentPageReportTemplate=""
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
          rowSpan={2}
          style={{ width: "40px" }}
          body={(rowData, item) => {
            return <>{item.rowIndex + 1}</>;
          }}
        />
        <Column
          className="text-center"
          rowSpan={2}
          field="id_nguoi_thuc_hien"
          body={(rowData, column) => 
            <>
              {decodeUnicode(rowData.ten_id_nguoi_thuc_hien)}
              {is_super_admin && <a onClick={() => confirmDelete(rowData)} style={{width: '30px', display: 'inline-block'}}>
                <i className="p-button-rounded p-button p-button-text p-1 pi pi-trash mr-2 flex align-items-center p-button-danger p-button-outlined"></i>
              </a>}
            </>
          }
        />
        <Column
          className="text-center"
          field="thu2_sang"
          body={(rowData, column) => {
            if (rowData.id_nguoi_thuc_hien == id) {
              return actionBodyTemplate(rowData, column, rowData.thu2_sang);
            } else {
              return decodeUnicode(rowData.thu2_sang);
            }
          }}
        />
        <Column
          className="text-center"
          field="thu2_chieu"
          body={(rowData, column) => {
            if (rowData.id_nguoi_thuc_hien == id) {
              return actionBodyTemplate(rowData, column, rowData.thu2_chieu);
            } else {
              return decodeUnicode(rowData.thu2_chieu);
            }
          }}
        />
        <Column
          className="text-center"
          field="thu3_sang"
          body={(rowData, column) => {
            if (rowData.id_nguoi_thuc_hien == id) {
              return actionBodyTemplate(rowData, column, rowData.thu3_sang);
            } else {
              return decodeUnicode(rowData.thu3_sang);
            }
          }}
        />
        <Column
          className="text-center"
          field="thu3_chieu"
          body={(rowData, column) => {
            if (rowData.id_nguoi_thuc_hien == id) {
              return actionBodyTemplate(rowData, column, rowData.thu3_chieu);
            } else {
              return decodeUnicode(rowData.thu3_chieu);
            }
          }}
        />
        <Column
          className="text-center"
          field="thu4_sang"
          body={(rowData, column) => {
            if (rowData.id_nguoi_thuc_hien == id) {
              return actionBodyTemplate(rowData, column, rowData.thu4_sang);
            } else {
              return decodeUnicode(rowData.thu4_sang);
            }
          }}
        />
        <Column
          className="text-center"
          field="thu4_chieu"
          body={(rowData, column) => {
            if (rowData.id_nguoi_thuc_hien == id) {
              return actionBodyTemplate(rowData, column, rowData.thu4_chieu);
            } else {
              return decodeUnicode(rowData.thu4_chieu);
            }
          }}
        />
        <Column
          className="text-center"
          field="thu5_sang"
          body={(rowData, column) => {
            if (rowData.id_nguoi_thuc_hien == id) {
              return actionBodyTemplate(rowData, column, rowData.thu5_sang);
            } else {
              return decodeUnicode(rowData.thu5_sang);
            }
          }}
        />
        <Column
          className="text-center"
          field="thu5_chieu"
          body={(rowData, column) => {
            if (rowData.id_nguoi_thuc_hien == id) {
              return actionBodyTemplate(rowData, column, rowData.thu5_chieu);
            } else {
              return decodeUnicode(rowData.thu5_chieu);
            }
          }}
        />
        <Column
          className="text-center"
          field="thu6_sang"
          body={(rowData, column) => {
            if (rowData.id_nguoi_thuc_hien == id) {
              return actionBodyTemplate(rowData, column, rowData.thu6_sang);
            } else {
              return decodeUnicode(rowData.thu6_sang);
            }
          }}
        />
        <Column
          className="text-center"
          field="thu6_chieu"
          body={(rowData, column) => {
            if (rowData.id_nguoi_thuc_hien == id) {
              return actionBodyTemplate(rowData, column, rowData.thu6_chieu);
            } else {
              return decodeUnicode(rowData.thu6_chieu);
            }
          }}
        />
        <Column
          className="text-center"
          field="thu7_sang"
          body={(rowData, column) => {
            if (rowData.id_nguoi_thuc_hien == id) {
              return actionBodyTemplate(rowData, column, rowData.thu7_sang);
            } else {
              return decodeUnicode(rowData.thu7_sang);
            }
          }}
        />
        <Column
          className="text-center"
          field="thu7_chieu"
          body={(rowData, column) => {
            if (rowData.id_nguoi_thuc_hien == id) {
              return actionBodyTemplate(rowData, column, rowData.thu7_chieu);
            } else {
              return decodeUnicode(rowData.thu7_chieu);
            }
          }}
        />
        <Column
          field="so_dien_thoai"
          body={(rowData, column) => {
            if (rowData.id_nguoi_thuc_hien == id) {
              return actionBodyTemplate(rowData, column, rowData.so_dien_thoai, "100%");
            } else {
              return decodeUnicode(rowData.so_dien_thoai);
            }
          }}
        />
        <Column
          field="link_bao_cao"
          style={{width: '10%'}}
          body={(rowData, column) => {
            if (rowData.id_nguoi_thuc_hien == id) {
              return actionBodyTemplate(rowData, column, rowData.link_bao_cao, "100%");
            } else {
              return <Link to={decodeUnicode(rowData.link_bao_cao)} target='_blank'>
                {decodeUnicode(rowData.link_bao_cao).replace(/\//g, '/ ')}
              </Link>
            }
          }}
        />
      </DataTable>
      <div className="row mb-2">
        <div className="col-12 col-sm-12">
          <Permission code={codePermAdd}></Permission>
          {is_super_admin && 
            <Link to={openDialog ? null : linkEdit + "/new"} onClick={() => editItem('new')}>
              <Button icon="fa fa-plus" label={labelAdd} />
            </Link>
          }
        </div>
      </div>
    </Card>
  );
};
export default CLIENT_LICH_TUANList;
