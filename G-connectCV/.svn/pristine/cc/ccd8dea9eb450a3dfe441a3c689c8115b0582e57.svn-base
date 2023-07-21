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
import { InputSwitch } from 'primereact/inputswitch';
import { ACTIVE, DEACTIVE } from 'shared/utils/appState';

import GC_CHUC_NANGFormView from "modules/GC_CHUC_NANG/GC_CHUC_NANGFormView";
import GC_CHUC_NANGForm from "modules/GC_CHUC_NANG/GC_CHUC_NANGForm";
import { GC_CHUC_NANGService } from "modules/GC_CHUC_NANG/GC_CHUC_NANGService";
import ChucnangForm from "./ChucnangForm";
import { getCurrentUserDefault } from 'shared/utils/getCurrentUserDefault';

dayjs.extend(utc);
const ChucnangList = () => {
    const { t, i18n } = useTranslation();
    const openDialog = !false;
    const fieldID = "id";
    const fieldSort = "stt";
    const fieldSortOrder = "ASC";
    const linkEdit = "/chucnangs/chucnang-form";
    const linkView = "/admin/GC_CHUC_NANG-view";
    const showAdvancedSearchButton = true;
    const codePermAdd = "PERM_GC_CHUC_NANG_ADD";
    const codePermModify = "PERM_GC_CHUC_NANG_MOD";
    const codePermDel = "PERM_GC_CHUC_NANG_DEL";
    const deleteMsg = "Bạn có chắc chắn xoá bản ghi này không?";
    const titlePage = "Danh sách Chức năng";
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
    const is_super_admin = getCurrentUserDefault().super_admin;
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
    const [selectedValue, setSelectedValue] = useState(null);
    const [showDialogView, setShowDialogView] = useState(false);
    const [showDialogEdit, setShowDialogEdit] = useState(false);
    const [showAdvancedSearch, setShowAdvancedSearch] = useState(false);
    const [listItems, setListItems] = useState(null);
    const [totalItems, setTotalItems] = useState(0);
    const [selectedItems, setSelectedItems] = useState([]);
    const [selectedId, setSelectedId] = useState(null);

    const [listRef_id_du_an, setListRef_id_du_an] = useState([]);
    const [listRef_id_linh_vuc, setListRef_id_linh_vuc] = useState([]);
    const [aDVSParams, setADVSParams] = useState({is_cong_bo: false, is_da_code: false, is_da_test: false});
    const [lazyParams, setLazyParams] = useState({
        ...DEFAULT_LIST_PARAM,
        ...{
            sortField: fieldSort,
            sortOrder: fieldSortOrder == "ASC" ? -1 : 1,
            filter: aDVSParams
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

        getListRef_id_du_an();
        getListRef_id_linh_vuc();
    }, [window.location.href]);
    const loadLazyData = () => {
        setLoading(true);
        console.log(lazyParams);
        let advanceSearch = mapPaginator(lazyParams);
        return GC_CHUC_NANGService.filterPage(advanceSearch).then((res) => {
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
    const getListRef_id_linh_vuc = () => {
        return GC_CHUC_NANGService.getAllRef_id_linh_vuc().then((res) => {
            res.data.map((x) => {
                x.Value = x.value;
                x.Text = x.label;
            });
            setListRef_id_linh_vuc(res.data);
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
    const addItem = async (id) => {
        setSelectedId(id);
        setShowDialogEdit(true)
    }
    const closeDialog = async () => {
        if (openDialog) setShowDialogEdit(false);
        if (openDialog) setShowDialogView(false);
    };
    const deleteItem = async (id) => {
        await GC_CHUC_NANGService.delete(id);
        loadLazyData();
    };
    const deleteItems = async (items) => {
        for (var i = 0; i < items.length; i++) {
            await GC_CHUC_NANGService.delete(items[i][fieldID]);
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
                <div className="flex flex-row justify-content-end text-center">
                    {is_super_admin && <Link
                        to={openDialog ? null : linkEdit + "/" + rowData[fieldID]}
                        onClick={() => editItem(rowData[fieldID])}
                    >
                        <i className="p-button-rounded p-button p-button-text p-1 pi pi-pencil mr-2 flex align-items-center"></i>
                    </Link>}
                    <Link
                        to={openDialog ? null : linkView + "/" + rowData[fieldID]}
                        onClick={() => viewItem(rowData[fieldID])}
                    >
                        <i className="p-button-rounded p-button p-button-text p-1 pi pi-info-circle mr-2 flex align-items-center"></i>
                    </Link>
                    {is_super_admin && <a onClick={() => confirmDelete(rowData)}>
                        <i className="p-button-rounded p-button p-button-text p-1 pi pi-trash mr-2 flex align-items-center p-button-danger p-button-outlined"></i>
                    </a>}
                </div>
            </React.Fragment>
        );
    };

    return (
        <div>
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
                        <GC_CHUC_NANGFormView
                            id={selectedId}
                            fnClose={closeDialog}
                        ></GC_CHUC_NANGFormView>
                    </div>
                </Dialog>
                <Dialog
                    showHeader={false}
                    showFooter={false}
                    visible={showDialogEdit}
                    onHide={() => setShowDialogEdit(false)}
                    position="center"
                    breakpoints={{ "960px": "80vw" }}
                    style={{ width: "50vw" }}
                >
                    <div className="flex justify-content-center flex-column pt-6 px-3">
                        <ChucnangForm
                            id={selectedId}
                            fnClose={closeDialog}
                            loadLazyData={loadLazyData}
                        ></ChucnangForm>
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
                        </div>
                    </div>
                    <div className="col-12 col-sm-1">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <i className="pi pi1-envelope" />
                                <Dropdown
                                    options={listRef_id_linh_vuc}
                                    optionValue="Value"
                                    optionLabel="Text"
                                    scrollHeight={"600px"}
                                    className=""
                                    value={aDVSParams.id_linh_vuc ?? ''}
                                    onChange={(e) => {
                                        var selectedOption = listRef_id_linh_vuc.find(
                                          (option) => option.Value === e.target.value
                                        );
                                        setSelectedValue(selectedOption);
                                        var filter = {
                                          ...aDVSParams,
                                          id_linh_vuc: e.target.value,
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
                                <label htmlFor="id_linh_vuc">Lĩnh vực</label>
                            </span>
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
                                        setSelectedValue(selectedOption);
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
                                    placeholder={selectedValue ? selectedValue.Text : "--Chọn--"}
                                    showClear
                                />
                                <label htmlFor="id_du_an">Dự án</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-1">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <InputSwitch 
                                    name="is_cong_bo" trueValue={ACTIVE} falseValue={DEACTIVE} 
                                    checked={aDVSParams.is_cong_bo} 
                                    onChange={(e) => {
                                        var filter = {
                                            ...aDVSParams,
                                            is_cong_bo: e.target.value,
                                        };
                                        setADVSParams(filter);
                                        setLazyParams({
                                            ...lazyParams,
                                            filter: filter,
                                        });
                                        setSelectedValue(Date.now());
                                    }} />
                                <label htmlFor="is_cong_bo">Đã công bố</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-1">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <InputSwitch 
                                    name="is_da_code" trueValue={ACTIVE} falseValue={DEACTIVE} 
                                    checked={aDVSParams.is_da_code} 
                                    onChange={(e) => {
                                        var filter = {
                                            ...aDVSParams,
                                            is_da_code: e.target.value,
                                        };
                                        setADVSParams(filter);
                                        setLazyParams({
                                            ...lazyParams,
                                            filter: filter,
                                        });
                                        setSelectedValue(Date.now());
                                    }} />
                                <label htmlFor="is_da_code">Đã code</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-1">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <InputSwitch 
                                    name="is_da_test" trueValue={ACTIVE} falseValue={DEACTIVE} 
                                    checked={aDVSParams.is_da_test} 
                                    onChange={(e) => {
                                        var filter = {
                                            ...aDVSParams,
                                            is_da_test: e.target.value,
                                        };
                                        setADVSParams(filter);
                                        setLazyParams({
                                            ...lazyParams,
                                            filter: filter,
                                        });
                                        setSelectedValue(Date.now());
                                    }} />
                                <label htmlFor="is_da_test">Đã test</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-5 text-right">
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
                        field="id_du_an"
                        sortable
                        header={"Dự án"}
                        body={(rowData, column) => decodeUnicode(rowData.ten_id_du_an)}
                    />
                    <Column
                        field="id_linh_vuc"
                        sortable
                        header={"Lĩnh vực"}
                        body={(rowData, column) => decodeUnicode(rowData.ten_id_linh_vuc)}
                    />
                    <Column
                        field="ma_chuc_nang"
                        sortable
                        header={"Mã chức năng"}
                        body={(rowData, column) => decodeUnicode(rowData.ma_chuc_nang)}
                    />
                    <Column
                        field="ten_chuc_nang"
                        sortable
                        header={"Tên chức năng"}
                        body={(rowData, column) => decodeUnicode(rowData.ten_chuc_nang)}
                    />
                    
                    <Column
                        field="is_cong_bo"
                        sortable
                        header={"Đã công bố"}
                        body={(rowData, column) => (
                            <div style={{
                                
                                textAlign: 'center'
                              }} >
                                {rowData.is_cong_bo ? "Đã công bố" : "Chưa công bố"}
                              </div>
                        )}
                    />
                    <Column
                        field="is_da_code"
                        sortable
                        header={"Đã code"}
                        body={(rowData, column) => (
                            <div style={{textAlign:'center'}}>
                                {rowData.is_da_code ? "Đã code" : "Chưa code"}
                            </div>
                            )}
                    />
                    <Column
                        field="is_da_test"
                        sortable
                        header={"Đã test"}
                        body={(rowData, column) => (
                            <div style={{textAlign : 'center'}}>
                                {rowData.is_da_test ? "Đã test" : "Chưa test"}
                            </div>
                        )}
                    />
                    <Column
                        field="noi_dung"
                        sortable
                        header={"Nội dung"}
                        body={(rowData, column) => decodeUnicode(rowData.noi_dung)}
                    />
                    <Column
                        field="file_dinh_kem"
                        sortable
                        header={"File đính kèm"}
                        body={(rowData, column) => decodeUnicode(rowData.file_dinh_kem)}
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
    )
}

export default ChucnangList
