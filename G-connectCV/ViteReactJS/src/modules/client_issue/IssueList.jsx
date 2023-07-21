
import React, { useState, useEffect, useRef } from 'react';
import dayjs from 'dayjs';
import utc from 'dayjs/plugin/utc'
import { Card } from 'primereact/card';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Button } from 'primereact/button';
import { InputText } from 'primereact/inputtext';
import { InputTextarea } from 'primereact/inputtextarea';
import { Dialog } from 'primereact/dialog';
import { Link, Outlet, Routes, useNavigate, useParams } from 'react-router-dom';
import { Dropdown } from 'primereact/dropdown';
import { Toast } from 'primereact/toast';
import { useTranslation } from 'react-i18next'
import { mapPaginator } from 'shared/utils';
import Permission from 'components/Permission';
import { Calendar } from 'components/Calendar';
import { useSelector, useDispatch } from 'react-redux';
import { setParamState } from 'store/listParamSlice';
import { decodeUnicode } from 'shared/utils/decodeHtmlEntites';
import { confirmDialogGlobal } from 'shared/components/confirmDialogGlobal';
import { DEFAULT_LIST_PARAM, DEFAULT_LIST_PAGE } from 'shared/app-settings';
import { getCurrentUserDefault } from 'shared/utils/getCurrentUserDefault';
import { GC_CHUC_NANGService } from "modules/GC_CHUC_NANG/GC_CHUC_NANGService";
import * as XLSX from 'xlsx';

import IssueForm from './IssueForm';
import { GC_VAN_DE_CAN_GIAI_QUYETService } from 'modules/GC_VAN_DE_CAN_GIAI_QUYET/GC_VAN_DE_CAN_GIAI_QUYETService';
import { da } from 'date-fns/locale';

// alert(getCurrentUserDefault().id)
dayjs.extend(utc)
const IssueList = () => {
    const { t, i18n } = useTranslation();
    const openDialog = false;
    const fieldID = 'id';
    const fieldSort = 'id';
    const fieldSortOrder = 'ASC';
    const linkEdit = '/issues/issues-form';
    const linkView = '/issues-formview';
    const showAdvancedSearchButton = true;
    const codePermAdd = 'PERM_GC_VAN_DE_CAN_GIAI_QUYET_ADD';
    const codePermModify = 'PERM_GC_VAN_DE_CAN_GIAI_QUYET_MOD';
    const codePermDel = 'PERM_GC_VAN_DE_CAN_GIAI_QUYET_DEL';
    const deleteMsg = 'Bạn có chắc chắn xoá bản ghi này không?';
    const titlePage = 'Danh sách Vấn đề cần giải quyết';
    const labelAdd = 'Thêm bản ghi';
    const labelDelete = 'Xóa bản ghi';
    const labelKeyword = 'Từ khoá...';
    const labelFind = 'Tìm kiếm nâng cao';
    const labelFindButton = 'Tìm kiếm';

    const columnBodyDate = (date) => {
        return dayjs(date).format('DD/MM/YYYY HH:mm')
    };
    const columnBodyState = (rowData) => {
        if (rowData) {
            return (<i className='pi pi-lock' title={'Bị khoá'}></i>)
        } else return (<>Good</>)
    }

    /**/
    /**/
    const id = getCurrentUserDefault().id;
    const is_super_admin = getCurrentUserDefault().super_admin;

    const dispatch = useDispatch();
    const toast = useRef(null);
    const listParamStore = useSelector(state => {
        var param = null;
        if (state.listParam.find(st => st && st.name == window.location.toString()))
            param = state.listParam.find(st => st && st.name == window.location.toString()).param;
        return param;
    });
    const [loading, setLoading] = useState(false);
    const [showDialogAdd, setShowDialogAdd] = useState(false);
    const [showDialogEdit, setShowDialogEdit] = useState(false);
    const [showAdvancedSearch, setShowAdvancedSearch] = useState(false);
    const [listItems, setListItems] = useState(null);
    const [totalItems, setTotalItems] = useState(0);
    const [selectedItems, setSelectedItems] = useState([]);
    const [selectedId, setSelectedId] = useState(null);

    const [searchItem, setSearchItem] = useState('');

    const [listRef_id_chuc_nang, setListRef_id_chuc_nang] = useState([]);
    const [listRef_id_cong_viec, setListRef_id_cong_viec] = useState([]);
    const [listRef_id_nguoi_gap, setListRef_id_nguoi_gap] = useState([]);
    const [listRef_id_nguoi_phoi_hop, setListRef_id_nguoi_phoi_hop] = useState([]);
    const [listRef_id_nguoi_giai_quyet, setListRef_id_nguoi_giai_quyet] = useState([]);
    const [listRef_id_du_an, setListRef_id_du_an] = useState([]);
    const [listTinhTrang, setListTinhTrang] = useState([{'Value': 1, 'Text': 'Đang xử lý'}, {'Value': 2, 'Text': 'Đã xong'}]);    

    const [selectedValue, setSelectedValue] = useState(null);
    const [aDVSParams, setADVSParams] = useState({});
    const [lazyParams, setLazyParams] = useState({
        ...DEFAULT_LIST_PARAM,
        ...{
            sortField: fieldSort,
            sortOrder: fieldSortOrder == 'ASC' ? -1 : 1,
            filter: {da_giai_quyet: 1}
        },
        ...listParamStore
    });


    useEffect(() => {

        loadLazyData();

    }, [lazyParams.refresh, selectedValue]);
    useEffect(() => {
        setTimeout(() => {
            if (listParamStore && listParamStore.pageYOffset) window.scrollTo(0, listParamStore.pageYOffset);
        }, 100);
        getListRef_id_du_an();
        getListRef_id_chuc_nang();
        getListRef_id_cong_viec();
        getListRef_id_nguoi_gap();
        getListRef_id_nguoi_phoi_hop();
        getListRef_id_nguoi_giai_quyet();
    }, [window.location.href]);

    const loadLazyData = () => {
        setLoading(true);
        let advanceSearch = mapPaginator(lazyParams);
        return GC_VAN_DE_CAN_GIAI_QUYETService.filterPage(advanceSearch).then(res => {
            setTotalItems(res.data.meta.total);
            setListItems(res.data.data);
            setLoading(false);
        });
    }
    const handleExport = (fileName) => {
        console.log(listItems)
        if (!listItems || listItems.length === 0) {
            alert("Không có dữ liệu để xuất Excel");
            return;
        } else {
            const exportData = listItems.map((data) => {
                return {
                    Chức_năng: data.ten_id_chuc_nang,
                    Vấn_đề: data.ten_van_de,
                    Người_gặp: data.ten_id_nguoi_gap,
                    Ngày: new Date(data.ngay_tao).toLocaleString('vi-VN', { timeZone: 'Asia/Ho_Chi_Minh', dateStyle: 'short', timeStyle: 'medium' }),
                    Người_Phối_hợp: data.ten_id_nguoi_phoi_hop,
                    Hướng_giải_quyết: data.huong_giai_quyet.replace(/<\/?p[^>]*>/g, '').replace(/"/g, '""').trim(),
                    Đã_xong: data.da_giai_quyet,
                    Người_giải_quyết: data.ten_id_nguoi_giai_quyet,

                }
            })
            console.log(exportData)
            const worksheet = XLSX.utils.json_to_sheet(exportData); // chuyển dữ liệu thành một trang tính
            const workbook = XLSX.utils.book_new(); // tạo một workbook mới
            XLSX.utils.book_append_sheet(workbook, worksheet, 'Issue'); // thêm trang tính vào workbook
            // Tải xuống tệp Excel
            XLSX.writeFile(workbook, 'Issue.xlsx');


        }
    }


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
        return GC_VAN_DE_CAN_GIAI_QUYETService.getAllRef_id_chuc_nang().then(res => {
            res.data.map(x => {
                x.Value = x.value;
                x.Text = x.label;
            });
            setListRef_id_chuc_nang(res.data);
        });
    }
    const getListRef_id_cong_viec = () => {
        return GC_VAN_DE_CAN_GIAI_QUYETService.getAllRef_id_cong_viec().then(res => {
            res.data.map(x => {
                x.Value = x.value;
                x.Text = x.label;
            });
            setListRef_id_cong_viec(res.data);
        });
    }
    const getListRef_id_nguoi_gap = () => {
        return GC_VAN_DE_CAN_GIAI_QUYETService.getAllRef_id_nguoi_gap().then(res => {
            res.data.map(x => {
                x.Value = x.value;
                x.Text = x.label;
            });
            setListRef_id_nguoi_gap(res.data);
        });
    }
    const getListRef_id_nguoi_phoi_hop = () => {
        return GC_VAN_DE_CAN_GIAI_QUYETService.getAllRef_id_nguoi_phoi_hop().then(res => {
            res.data.map(x => {
                x.Value = x.value;
                x.Text = x.label;
            });
            setListRef_id_nguoi_phoi_hop(res.data);
        });
    }
    const getListRef_id_nguoi_giai_quyet = () => {
        return GC_VAN_DE_CAN_GIAI_QUYETService.getAllRef_id_nguoi_giai_quyet().then(res => {
            res.data.map(x => {
                x.Value = x.value;
                x.Text = x.label;
            });
            setListRef_id_nguoi_giai_quyet(res.data);
        });
    }

    const onPage = (event) => {
        setLazyParams({ ...lazyParams, ...event, refresh: Date.now() });
    }
    const onSort = (event) => {
        setLazyParams({ ...lazyParams, ...event, refresh: Date.now() });
    }
    const onFilter = (event) => {
        if (searchItem) {
            const filteredList = listItems.filter(item => {
                // Modify the condition based on your filtering logic
                return item.ten_van_de.toLowerCase().includes(searchItem.toLowerCase()) ||
                    item.huong_giai_quyet.toLowerCase().includes(searchItem.toLowerCase())
                    ;
            });
            // Update the listItems with the filteredList
            setListItems(filteredList);
        }
        else {
            loadLazyData()
        }
    }
    const onChangeKeySearch = (text) => {
        //debugger
        // setLazyParams({ ...lazyParams, keySearch: text });
        setSearchItem({ text });
    }
    const onEnterKeySearch = (event) => {
        //debugger
        if (event.key === 'Enter') {
            onFilter();
        }
        //Backspace
    }
    const onSelectionChange = (event) => {
        const value = event.value;
        setSelectedItems(value);
    }
    const onShowAdvancedSearch = (event) => {
        setShowAdvancedSearch(!showAdvancedSearch);
    }
    const editItem = async (id) => {
        setSelectedId(id);
        dispatch(setParamState({ ...lazyParams, pageYOffset: window.pageYOffset }));
        setShowDialogEdit(true)
    }
    const addItem = async (id) => {
        setSelectedId(id);
        setShowDialogEdit(true)
    }
    const closeDialog = async () => {
        setShowDialogEdit(false);
        setShowDialogAdd(false);
    }
    const paginatorLeft = <>
        <Button type="button" icon="pi pi-refresh" className="p-button-text p-button-secondary" onClick={() => loadLazyData()} />
        <Dropdown options={DEFAULT_LIST_PAGE} className='mr-2'
            value={lazyParams.rows}
            onChange={e => setLazyParams({ ...lazyParams, first: 0, page: 1, rows: e.value })}
        />
    </>;

    

    function transformData(rowData) {
        return decodeUnicode(rowData.ten_id_nguoi_giai_quyet);
    }
    function transformDatanph(rowData) {
        return decodeUnicode(rowData.ten_id_nguoi_phoi_hop);
    }
    function transformDatang(rowData) {
        return decodeUnicode(rowData.ten_id_nguoi_gap);
    }

    const actionBodyTemplate = (rowData) => {
        //sdsada
        return (
            <React.Fragment>
                <div className='flex flex-row justify-content-end' >
                    <Link to={openDialog ? null : linkEdit + '/' + rowData[fieldID]} onClick={() => editItem(rowData[fieldID])}><i className="p-button-rounded p-button p-button-text p-1 pi pi-pencil mr-2 flex align-items-center"></i></Link>
                    {/* <Link to={openDialog ? null : linkView + '/' + rowData[fieldID]} onClick={() => viewItem(rowData[fieldID])}><i className="p-button-rounded p-button p-button-text p-1 pi pi-info-circle mr-2 flex align-items-center"></i></Link> */}
                </div>
            </React.Fragment>
        );
    }

    return (

        <div className='text-center-' >
            <Card title={titlePage} >
                <Toast ref={toast} />

                <Dialog showHeader={false} showfooter='false'position="center" visible={showDialogEdit} onHide={() => setShowDialogEdit(false)} style={{ width: '40vw' }} >
                    <div className="flex justify-content-center flex-column">
                        <IssueForm id={selectedId} fnClose={closeDialog} loadLazyData={loadLazyData} ></IssueForm>
                    </div>
                </Dialog>

                {
                    <div className='row mb-2'>
                        <div className="col-12 col-sm-2">
                            <div className="field">
                                <InputText autoFocus
                                    placeholder={labelKeyword}
                                    onKeyDown={onEnterKeySearch}
                                    onChange={(e) =>
                                        setSearchItem(e.target.value)}
                                    value={searchItem}
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
                        <div className="col-12 col-sm-2">
                            <div className="field">
                                <span className="p-float-label p-input-icon-right">
                                    <i className="pi pi1-envelope" />
                                    <Dropdown options={listRef_id_chuc_nang.filter(x=>x.id_du_an==aDVSParams.id_du_an || aDVSParams.id_du_an==null)}
                                        value={aDVSParams.id_chuc_nang ?? ''}
                                        onChange={(e) => {
                                            var selectedOption = listRef_id_chuc_nang.find(
                                                (option) => option.Value === e.target.value
                                            );
                                            setSelectedValue(selectedOption);
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
                                        placeholder={selectedValue ? selectedValue.Text : "--Chọn--"}
                                        showClear
                                    />
                                    <label htmlFor="id_chuc_nang" >Chức năng</label>
                                </span>
                            </div>
                        </div>
                        <div className="col-12 col-sm-1">
                            <div className="field">
                                <span className="p-float-label p-input-icon-right">
                                    <i className="pi pi1-envelope" />
                                    <Dropdown
                                        options={listRef_id_nguoi_gap}
                                        optionValue="Value"
                                        optionLabel="Text"
                                        scrollHeight={"600px"}
                                        className=""
                                        value={aDVSParams.id_nguoi_gap ?? ''}
                                        onChange={(e) => {
                                            var selectedOption = listRef_id_nguoi_gap.find(
                                                (option) => option.Value === e.target.value
                                            );
                                            setSelectedValue(selectedOption);
                                            var filter = {
                                                ...aDVSParams,
                                                id_nguoi_gap: e.target.value,
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
                                    <label htmlFor="id_nguoi_gap">Người gặp</label>
                                </span>
                            </div>
                        </div>
                        <div className="col-12 col-sm-1">
                            <div className="field">
                                <span className="p-float-label p-input-icon-right">
                                    <i className="pi pi1-envelope" />
                                    <Dropdown
                                        options={listRef_id_nguoi_phoi_hop}
                                        optionValue="Value"
                                        optionLabel="Text"
                                        scrollHeight={"600px"}
                                        className=""
                                        value={aDVSParams.id_nguoi_phoi_hop ?? ''}
                                        onChange={(e) => {
                                            var selectedOption = listRef_id_nguoi_phoi_hop.find(
                                                (option) => option.Value === e.target.value
                                            );
                                            setSelectedValue(selectedOption);
                                            var filter = {
                                                ...aDVSParams,
                                                id_nguoi_phoi_hop: e.target.value,
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
                                    <label htmlFor="id_nguoi_phoi_hop">Phối hợp</label>
                                </span>
                            </div>
                        </div>
                        <div className="col-12 col-sm-1">
                            <div className="field">
                                <span className="p-float-label p-input-icon-right">
                                    <i className="pi pi1-envelope" />
                                    <Dropdown
                                        options={listRef_id_nguoi_giai_quyet}
                                        optionValue="Value"
                                        optionLabel="Text"
                                        scrollHeight={"600px"}
                                        className=""
                                        value={aDVSParams.id_nguoi_giai_quyet ?? ''}
                                        onChange={(e) => {
                                            var selectedOption = listRef_id_nguoi_giai_quyet.find(
                                                (option) => option.Value === e.target.value
                                            );
                                            setSelectedValue(selectedOption);
                                            var filter = {
                                                ...aDVSParams,
                                                id_nguoi_giai_quyet: e.target.value,
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
                                    <label htmlFor="id_nguoi_giai_quyet">Giải quyết</label>
                                </span>
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
                                        value={aDVSParams.da_giai_quyet ?? ''}
                                        onChange={(e) => {
                                            var selectedOption = listTinhTrang.find(
                                                (option) => option.Value === e.target.value
                                            );
                                            setSelectedValue(selectedOption);
                                            var filter = {
                                                ...aDVSParams,
                                                da_giai_quyet: e.target.value,
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
                                    <label htmlFor="da_giai_quyet">Tình trạng</label>
                                </span>
                            </div>
                        </div>
                        <div className="col-12 col-sm-3 text-right ">
                            <Permission code={codePermAdd}></Permission>
                            {/* <Link to={linkEdit + "/new"}>
                                <Button icon="fa fa-plus" label={labelAdd} />
                            </Link> */}
                            <Button onClick={() => addItem(null)} icon="fa fa-plus" label='Thêm vấn đề' ></Button>

                            {false && <Button onClick={handleExport}>Export Excel</Button>}
                        </div>
                    </div>
                }


                <DataTable value={listItems} dataKey={fieldID} emptyMessage={'Không có kết quả'}
                    style={{}}
                    size="small"
                    lazy responsiveLayout="stack" paginator showGridlines
                    paginatorTemplate="CurrentPageReport FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink"
                    currentPageReportTemplate="{first} - {last} / {totalRecords}"
                    paginatorLeft={paginatorLeft} totalRecords={totalItems}
                    loading={loading}
                    rowsPerPageOptions={DEFAULT_LIST_PAGE}
                    rows={lazyParams.rows} first={lazyParams.first} sortField={lazyParams.sortField} sortOrder={lazyParams.sortOrder}
                    onPage={onPage} onSort={onSort} onSelectionChange={onSelectionChange}
                >
                    <Column className='text-center' style={{ width: '40px' }} body={(rowData, item) => {
                        return (<>{item.rowIndex + 1}</>)
                    }} header="#" />
                    {/* <Column selectionMode="multiple" headerStyle={{ width: '3em' }}></Column> */}
                    <Column field="id_chuc_nang" sortable header={'Chức năng'} body={(rowData, column) => decodeUnicode(rowData.ten_id_chuc_nang)} />
                    <Column field="ten_van_de" sortable header={'Tên vấn đề'} body={(rowData, column) => decodeUnicode(rowData.ten_van_de)} />
                    <Column
                        field="id_nguoi_gap"
                        sortable header={'Người gặp phải'}
                        style={{ width: '150px', textAlign: 'center' }} body={(rowData) => {
                            if (rowData.id_nguoi_gap == id) {

                                return (
                                    <button style={{
                                        backgroundColor: 'white',
                                        border: 'none',
                                        color: 'green',
                                        display: 'flex',
                                        justifyContent: 'center',
                                        textAlign: 'center',
                                        margin: '0 auto',
                                        
                                    }}
                                        onClick={() => editItem(rowData[fieldID])}>{transformDatang(rowData)}</button>)
                            }

                            else {
                                return decodeUnicode(rowData.ten_id_nguoi_gap);
                            }
                        }

                        } />

                    <Column style={{ width: '200px' }}
                        className={'text-center'}
                        sortable
                        field="ngay_tao" body={(rowData, column) =>
                            columnBodyDate(rowData.ngay_tao)} header={'Ngày tạo'} />

                    <Column field="id_nguoi_phoi_hop"
                        style={{ width: '150px', textAlign: 'center' }}
                        sortable
                        header={'Người phối hợp'}
                        body={(rowData) => {
                            return (
                                !rowData.da_giai_quyet && (rowData.id_nguoi_phoi_hop == id || rowData.ten_id_nguoi_phoi_hop==null) ?
                                    <button style={{ backgroundColor: 'white', border: '0 solid #ccc', color: 'green', display: 'flex', justifyContent: 'center', textAlign: 'center', margin: '0 auto' }}
                                        onClick={() => editItem(rowData[fieldID])}>{rowData.ten_id_nguoi_phoi_hop==null ? '_' : decodeUnicode(rowData.ten_id_nguoi_phoi_hop)}</button> 
                                    : decodeUnicode(rowData.ten_id_nguoi_phoi_hop)
                                )
                        }
                    } />
                    <Column field="huong_giai_quyet"
                        sortable
                        header={'Hướng giải quyết'}
                        body={(rowData, column) => decodeUnicode(rowData.huong_giai_quyet.replace(/<\/?p[^>]*>/g, ''))} />

                    <Column
                        field="da_giai_quyet"
                        style={{ width: '100px' }}
                        sortable
                        header={"Đã xong"}
                        body={(rowData, column) => (
                            <div style={{ color: rowData.da_giai_quyet ? "blue" : "red", textAlign : 'center'}}>
                                {rowData.da_giai_quyet ? "Đã xong" : "Đang xử lý"}
                            </div>
                        )}
                    />

                    <Column field="id_nguoi_giai_quyet"
                        style={{ width: '150px', textAlign: 'center' }}
                        sortable
                        header={'Người giải quyết'}
                        body={(rowData) => {
                            return (
                                !rowData.da_giai_quyet && (rowData.id_nguoi_giai_quyet == id || rowData.ten_id_nguoi_giai_quyet==null) ?
                                    <button style={{ backgroundColor: 'white', border: '0 solid #ccc', color: 'green', display: 'flex', justifyContent: 'center', textAlign: 'center', margin: '0 auto' }}
                                        onClick={() => editItem(rowData[fieldID])}>{rowData.ten_id_nguoi_giai_quyet==null ? '_' : transformData(rowData)}</button> 
                                    : transformData(rowData)
                                )
                            }
                        }
                    />
                </DataTable>


            </Card>
        </div>


    )
}

export default IssueList