import React, { useState, useEffect, useRef } from 'react';
import dayjs from 'dayjs';
import utc from 'dayjs/plugin/utc'
import { Card } from 'primereact/card';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Button } from 'primereact/button';
import { InputText } from 'primereact/inputtext';
import { InputTextarea } from 'primereact/inputtextarea';
import { Link } from 'react-router-dom';
import { Dropdown } from 'primereact/dropdown';
import { Toast } from 'primereact/toast';
import { Dialog } from 'primereact/dialog';
import { useTranslation } from 'react-i18next'
import { mapPaginator } from 'shared/utils';
import Permission from 'components/Permission';
import { Calendar } from 'components/Calendar';
import { useSelector, useDispatch } from 'react-redux';
import { setParamState } from 'store/listParamSlice';
import { decodeUnicode, formatResourceLanguage } from 'shared/utils/decodeHtmlEntites';
import { confirmDialogGlobal } from 'shared/components/confirmDialogGlobal';
import { DEFAULT_LIST_PARAM, DEFAULT_LIST_PAGE } from 'shared/app-settings';

import { MyTmService  } from 'modules/MyTm/MyTmService';

dayjs.extend(utc)
const MyTmList = () => {
    const { t, i18n } = useTranslation();
    const fieldID = 'NM_USR_ID';
    const fieldSort = 'NM_USR_ID';
    const fieldSortOrder = 'ASC';
    const linkEdit = '/admin/MyTm-form';
    const showAdvancedSearchButton = true;
    const codePermAdd = 'PERM_MyTm_ADD';
    const codePermModify = 'PERM_MyTm_MOD';
    const codePermDel = 'PERM_MyTm_DEL';
    const deleteMsg = t('rbkey_CnfrmDltnMSG', 'Bạn có chắc chắn muốn xóa (các) mục đã chọn không?')
    const titlePage = t('rbkey_MyTmLBL', 'Nhóm của tôi');
    const labelClose = 'Đóng';
    const labelAdd = 'Thêm bản ghi';
    const labelDelete = 'Xóa bản ghi';
    const labelKeyword = t('rbkey_SrchLBL', 'Tìm kiếm');//    'Từ khoá...';
    const labelFind = t('rbkey_AdvncdFltrLBL', 'Bộ lọc nâng cao ');
    const labelFindButton = t('rbkey_SrchLBL', 'Tìm kiếm');
    const columnBodyDate = (date) => {
        return dayjs(date).format('DD/MM/YYYY HH:mm')
    };
    const columnBodyState = (rowData) => {
        if (rowData) {
            return (<i className='pi pi-lock' title={'Bị khoá'}></i>)
        } else return (<>Good</>)
    }
    const dialogFooter = <div className="flex justify-content-center"><Button label={labelClose} className="btnClose" style={{width:100}} icon='fa fa-close' autoFocus onClick={() => setShowDialog('')} /></div>;
    /**/
    /**/
    const dispatch = useDispatch();
    const toast = useRef(null);
    const listParamStore = useSelector(state => {
        var param = null;
        if(state.listParam.find(st => st && st.name == window.location.toString()))
            param = state.listParam.find(st => st && st.name == window.location.toString()).param;
        return param;
    });
    const [loading, setLoading] = useState(false);
    const [showDialog, setShowDialog] = useState(false);
    const [showAdvancedSearch, setShowAdvancedSearch] = useState(false);
    const [rowData, setRowData] = useState({});
    const [listItems, setListItems] = useState(null);
    const [totalItems, setTotalItems] = useState(0);
    const [selectedItems, setSelectedItems] = useState([]);
    const [lazyParams, setLazyParams] = useState({
        ...DEFAULT_LIST_PARAM,
        ...{
            sortField: fieldSort,
            sortOrder: fieldSortOrder == 'ASC' ? -1 : 1,
        }, 
        ...listParamStore});

    useEffect(() => {
        loadLazyData();
    }, [lazyParams.refresh]);
    useEffect(() => {
        setTimeout(() => {
            if(listParamStore && listParamStore.pageYOffset) window.scrollTo(0, listParamStore.pageYOffset);
        }, 1000);

    }, [window.location.href]);
    const loadLazyData = () => {
        setLoading(true);
        console.log(lazyParams)
        let advanceSearch = mapPaginator(lazyParams);
        return MyTmService.filterPage(advanceSearch).then(res => {
            setTotalItems(res.data.TotalRecords);
            setListItems(res.data.Data);
            setLoading(false);
        });
    }

    const onPage = (event) => {
        setLazyParams({...lazyParams, ...event, refresh: Date.now()});
    }
    const onSort = (event) => {
        setLazyParams({...lazyParams, ...event, refresh: Date.now()});
    }
    const onFilter = (event) => {
        setLazyParams({...lazyParams, page: 0, first: 0, refresh: Date.now()});
    }
    const onChangeKeySearch = (text) => {
        //debugger
        setLazyParams({...lazyParams, keySearch: text});
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
    const editItem = async () => {
        dispatch(setParamState({...lazyParams, pageYOffset: window.pageYOffset}));
    }
    const deleteItem = async (id) => {
        await MyTmService.delete(id);
        loadLazyData();
    }
    const deleteItems = async (items) => {
        for(var i = 0; i < items.length; i++) {
            await MyTmService.delete(items[i][fieldID]);
        }
        loadLazyData();
    }
    const confirmDelete = (data) => {
        confirmDialogGlobal({
            message: deleteMsg,
            accept: () => data ? deleteItem(data[fieldID]) : deleteItems(selectedItems)
        });
    };
    const paginatorLeft = <>
        <Button type="button" icon="pi pi-refresh" className="p-button-text p-button-secondary" onClick={() => loadLazyData()} />
        <Dropdown options={DEFAULT_LIST_PAGE} className='mr-2'
            value={lazyParams.rows}
            onChange={e => setLazyParams({...lazyParams, first: 0, page: 1, rows: e.value})} 
        />
    </>;
    const actionBodyTemplate = (rowData) => {
        return (
            <React.Fragment>
                <div className='flex flex-row justify-content-end' >

                    <Link onClick={() => { setRowData(rowData);setShowDialog('ILTAssignment'); }} title={t('rbkey_TrnngsLBL', 'Đào tạo')}><i className="p-button-rounded p-button p-button-text p-1 fa fa-user fa-lg mr-2 flex align-items-center"></i></Link>
                    <Link onClick={() => { setRowData(rowData);setShowDialog('CourseAssignment'); }} title={t('rbkey_CrssLBL', 'Các khóa học')}><i className="p-button-rounded p-button p-button-text p-1 fa fa-book fa-lg mr-2 flex align-items-center"></i></Link>
                    <Link onClick={() => { setRowData(rowData);setShowDialog('ViewDetails'); }} title={t('rbkey_RprtLBL', 'Báo cáo')}><i className="p-button-rounded p-button p-button-text p-1 fa fa-list-alt fa-lg pre mr-2 flex align-items-center"></i></Link>
                </div>
            </React.Fragment>
        );  
    }
    /**/   
    return (
        <>
            <Dialog visible={showDialog == 'info'} onHide={() => setShowDialog('')} position="top" footer={dialogFooter} showHeader={false} breakpoints={{ '960px': '80vw' }} style={{ width: '50vw' }}>
                <div className="flex justify-content-center flex-column">
                    <Card title={titlePage}>

                        <div className="col-12">
                            <div className="col-sm-4">
                                <label htmlFor="VC_USR_NM">
                                    {t('rbkey_UsrNmLBL', 'Tên tài khoản')}
                                </label>
                            </div>
                            <div className="col-sm-8">
                                <label htmlFor="rbkey_UsrNmLBL" className={'p-inputtext'}>
                                    {decodeUnicode(rowData.VC_USR_NM)}
                                </label>
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-4">
                                <label htmlFor="VC_EML_ADDRSS">
                                    {t('rbkey_EmlLBL', 'E-mail')}
                                </label>
                            </div>
                            <div className="col-sm-8">
                                <label htmlFor="rbkey_EmlLBL" className={'p-inputtext'}>
                                    {decodeUnicode(rowData.VC_EML_ADDRSS)}
                                </label>
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-4">
                                <label htmlFor="VC_CNTCT_NMBR_MBL">
                                    {t('rbkey_MblNmbrLBL', 'Số điện thoại di động')}
                                </label>
                            </div>
                            <div className="col-sm-8">
                                <label htmlFor="rbkey_MblNmbrLBL" className={'p-inputtext'}>
                                    {decodeUnicode(rowData.VC_CNTCT_NMBR_MBL)}
                                </label>
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-4">
                                <label htmlFor="VC_UIDAI">
                                    {t('rbkey_UdLBL', 'Mã nhân viên')}
                                </label>
                            </div>
                            <div className="col-sm-8">
                                <label htmlFor="rbkey_UdLBL" className={'p-inputtext'}>
                                    {decodeUnicode(rowData.VC_UIDAI)}
                                </label>
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-4">
                                <label htmlFor="VC_LGN_CD">
                                    {t('rbkey_LgnCdLBL', 'ID Đăng nhập')}
                                </label>
                            </div>
                            <div className="col-sm-8">
                                <label htmlFor="rbkey_LgnCdLBL" className={'p-inputtext'}>
                                    {decodeUnicode(rowData.VC_LGN_CD)}
                                </label>
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-4">
                                <label htmlFor="VC_RL_NM">
                                    {t('rbkey_PrmryRlLBL', 'Vai trò chính')}
                                </label>
                            </div>
                            <div className="col-sm-8">
                                <label htmlFor="rbkey_PrmryRlLBL" className={'p-inputtext'}>
                                    {decodeUnicode(rowData.VC_RL_NM)}
                                </label>
                            </div>
                        </div>
{/*, NM_USR_ID, VC_LGN_CD, VC_USR_NM, VC_EML_ADDRSS, VC_RL_NM, VC_UIDAI, VC_CNTCT_NMBR_MBL*/}
                    </Card>
                </div>
            </Dialog>
            <Dialog visible={showDialog != '' && showDialog != 'info'} onHide={() => setShowDialog('')} position="top" footer={dialogFooter} showHeader={false} breakpoints={{ '960px': '80vw' }} style={{ width: '50vw' }}>
                <div className="flex justify-content-center flex-column">
                    <Card title={titlePage}>

                        <div className="col-12">
                            <div className="col-sm-6">
                                <div className="p-card-title" style={{ fontSize: '1.1rem', borderBottom: '1px solid' }}>
                                    {t('rbkey_NmntdTrngsLBL', 'Các khóa đào tạo được đề xuất')}
                                </div>
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <DataTable value={[]} dataKey={''} emptyMessage={t('rbkey_NRcrdsFndMSG', 'Không có dữ liệu được tìm thấy.')}
                                    size="small" lazy responsiveLayout="stack" paginator showGridlines
                                    paginatorTemplate="" loading={loading} rowsPerPageOptions={DEFAULT_LIST_PAGE} 
                                    selection={selectedItems} selectionMode="checkbox" 
                                >
                                    <Column className='text-center' style={{ width: '40px' }} body={(rowData, item)=>{
                                       return(<>{item.rowIndex + 1}</>)
                                    }} header="#" />
                                    <Column selectionMode="multiple" headerStyle={{ width: '3em' }}></Column>

                    <Column field="VC_ILT_NM" sortable header={t('rbkey_ClssrmTrnngNmLBL', 'Tên Lớp học tập trung')} body={(rowData, column) => decodeUnicode(rowData.VC_ILT_NM)} />
                    <Column field="NMNTN_STTS" sortable header={t('rbkey_NmntnSttsLBL', 'Trạng thái đề xuất')} body={(rowData, column) => decodeUnicode(rowData.NMNTN_STTS)} />
                    <Column field="DT_STRT_DT" sortable header={t('rbkey_StrtDtLBL', 'Ngày bắt đầu')} style={{ width: '200px' }} className={'text-center'} body={(rowData, column) => columnBodyDate(rowData.DT_STRT_DT)} />
                    <Column field="DT_END_DT" sortable header={t('rbkey_EdDtLBL', 'Ngày Kết thúc')} style={{ width: '200px' }} className={'text-center'} body={(rowData, column) => columnBodyDate(rowData.DT_END_DT)} />
                    <Column field="VC_ACTNS" sortable header={t('rbkey_ActnsLBL', 'Các tác vụ')} body={(rowData, column) => decodeUnicode(rowData.VC_ACTNS)} />
                                </DataTable>
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-6">
                                <div className="p-card-title" style={{ fontSize: '1.1rem', borderBottom: '1px solid' }}>
                                    {t('rbkey_AvlblTrngsLBL', 'Đào tạo khả dụng')}
                                </div>
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <DataTable value={[]} dataKey={''} emptyMessage={t('rbkey_NRcrdsFndMSG', 'Không có dữ liệu được tìm thấy.')}
                                    size="small" lazy responsiveLayout="stack" paginator showGridlines
                                    paginatorTemplate="" loading={loading} rowsPerPageOptions={DEFAULT_LIST_PAGE} 
                                    selection={selectedItems} selectionMode="checkbox" 
                                >
                                    <Column className='text-center' style={{ width: '40px' }} body={(rowData, item)=>{
                                       return(<>{item.rowIndex + 1}</>)
                                    }} header="#" />
                                    <Column selectionMode="multiple" headerStyle={{ width: '3em' }}></Column>

                    <Column field="VC_ILT_NM" sortable header={t('rbkey_ClssrmTrnngNmLBL', 'Tên Lớp học tập trung')} body={(rowData, column) => decodeUnicode(rowData.VC_ILT_NM)} />
                    <Column field="DT_STRT_DT" sortable header={t('rbkey_StrtDtLBL', 'Ngày bắt đầu')} style={{ width: '200px' }} className={'text-center'} body={(rowData, column) => columnBodyDate(rowData.DT_STRT_DT)} />
                    <Column field="DT_END_DT" sortable header={t('rbkey_EdDtLBL', 'Ngày Kết thúc')} style={{ width: '200px' }} className={'text-center'} body={(rowData, column) => columnBodyDate(rowData.DT_END_DT)} />
                                </DataTable>
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-6">
                                <div className="p-card-title" style={{ fontSize: '1.1rem', borderBottom: '1px solid' }}>
                                    {t('rbkey_AssgndCrssLBL', 'Các khóa học được gán')}
                                </div>
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <DataTable value={[]} dataKey={''} emptyMessage={t('rbkey_NRcrdsFndMSG', 'Không có dữ liệu được tìm thấy.')}
                                    size="small" lazy responsiveLayout="stack" paginator showGridlines
                                    paginatorTemplate="" loading={loading} rowsPerPageOptions={DEFAULT_LIST_PAGE} 
                                    selection={selectedItems} selectionMode="checkbox" 
                                >
                                    <Column className='text-center' style={{ width: '40px' }} body={(rowData, item)=>{
                                       return(<>{item.rowIndex + 1}</>)
                                    }} header="#" />
                                    <Column selectionMode="multiple" headerStyle={{ width: '3em' }}></Column>

                    <Column field="VC_CRS_NM" sortable header={t('rbkey_CrsLBL', 'Khóa học')} body={(rowData, column) => decodeUnicode(rowData.VC_CRS_NM)} />
                    <Column field="CH_CRS_STTS" sortable header={t('rbkey_SttsLBL', 'Trạng thái')} body={(rowData, column) => decodeUnicode(rowData.CH_CRS_STTS)} />
                    <Column field="DT_STRT_DT" sortable header={t('rbkey_StrtDtLBL', 'Ngày bắt đầu')} style={{ width: '200px' }} className={'text-center'} body={(rowData, column) => columnBodyDate(rowData.DT_STRT_DT)} />
                    <Column field="DT_END_DT" sortable header={t('rbkey_EdDtLBL', 'Ngày Kết thúc')} style={{ width: '200px' }} className={'text-center'} body={(rowData, column) => columnBodyDate(rowData.DT_END_DT)} />
                    <Column field="NM_CRS_CRDT_HRS" sortable header={t('rbkey_CrdtHrsLBL', 'Giờ tín chỉ')} body={(rowData, column) => decodeUnicode(rowData.NM_CRS_CRDT_HRS)} />
                    <Column field="DT_CMPLTN_DT" sortable header={t('rbkey_CmpltnDtLBL', 'Ngày hoàn thành')} style={{ width: '200px' }} className={'text-center'} body={(rowData, column) => columnBodyDate(rowData.DT_CMPLTN_DT)} />
                                </DataTable>
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-6">
                                <div className="p-card-title" style={{ fontSize: '1.1rem', borderBottom: '1px solid' }}>
                                    {t('rbkey_AvlblCrssLBL', 'Các khóa học trực tuyến có sẵn')}
                                </div>
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <DataTable value={[]} dataKey={''} emptyMessage={t('rbkey_NRcrdsFndMSG', 'Không có dữ liệu được tìm thấy.')}
                                    size="small" lazy responsiveLayout="stack" paginator showGridlines
                                    paginatorTemplate="" loading={loading} rowsPerPageOptions={DEFAULT_LIST_PAGE} 
                                    selection={selectedItems} selectionMode="checkbox" 
                                >
                                    <Column className='text-center' style={{ width: '40px' }} body={(rowData, item)=>{
                                       return(<>{item.rowIndex + 1}</>)
                                    }} header="#" />
                                    <Column selectionMode="multiple" headerStyle={{ width: '3em' }}></Column>

                    <Column field="VC_CRS_NM" sortable header={t('rbkey_CrsLBL', 'Khóa học')} body={(rowData, column) => decodeUnicode(rowData.VC_CRS_NM)} />
                    <Column field="DT_STRT_DT" sortable header={t('rbkey_StrtDtLBL', 'Ngày bắt đầu')} style={{ width: '200px' }} className={'text-center'} body={(rowData, column) => columnBodyDate(rowData.DT_STRT_DT)} />
                    <Column field="DT_END_DT" sortable header={t('rbkey_EdDtLBL', 'Ngày Kết thúc')} style={{ width: '200px' }} className={'text-center'} body={(rowData, column) => columnBodyDate(rowData.DT_END_DT)} />
                    <Column field="NM_CRS_CRDT_HRS" sortable header={t('rbkey_CrdtHrsLBL', 'Giờ tín chỉ')} body={(rowData, column) => decodeUnicode(rowData.NM_CRS_CRDT_HRS)} />
                                </DataTable>
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <DataTable value={[]} dataKey={''} emptyMessage={t('rbkey_NRcrdsFndMSG', 'Không có dữ liệu được tìm thấy.')}
                                    size="small" lazy responsiveLayout="stack" paginator showGridlines
                                    paginatorTemplate="" loading={loading} rowsPerPageOptions={DEFAULT_LIST_PAGE} 
                                    selection={selectedItems} selectionMode="checkbox" 
                                >
                                    <Column className='text-center' style={{ width: '40px' }} body={(rowData, item)=>{
                                       return(<>{item.rowIndex + 1}</>)
                                    }} header="#" />
                                    <Column selectionMode="multiple" headerStyle={{ width: '3em' }}></Column>

                    <Column field="VC_CRPRT_NM" sortable header={t('rbkey_CrprtNmLBL', 'Tên công ty')} body={(rowData, column) => decodeUnicode(rowData.VC_CRPRT_NM)} />
                    <Column field="VC_RL_NM" sortable header={t('rbkey_PrmryRlLBL', 'Vai trò chính')} body={(rowData, column) => decodeUnicode(rowData.VC_RL_NM)} />
                    <Column field="VC_RPRTNG_ATHRTY_LGN_CD" sortable header={t('rbkey_LgnCdRprtngAthrtyLBL', 'Mã đăng nhập (Cơ quan báo cáo)')} body={(rowData, column) => decodeUnicode(rowData.VC_RPRTNG_ATHRTY_LGN_CD)} />
                    <Column field="VC_RPRTNG_ATHRTY_NM" sortable header={t('rbkey_RprtngAthrtyNmLBL', 'Tên Cơ quan Báo cáo')} body={(rowData, column) => decodeUnicode(rowData.VC_RPRTNG_ATHRTY_NM)} />
                    <Column field="VC_JB_RL_NM" sortable header={t('rbkey_JbRlLBL', 'Vai trò công việc')} body={(rowData, column) => decodeUnicode(rowData.VC_JB_RL_NM)} />
                    <Column field="VC_LCTN_NM" sortable header={t('rbkey_LctnLBL', 'Vị trí')} body={(rowData, column) => decodeUnicode(rowData.VC_LCTN_NM)} />
                    <Column field="VC_GRP_NM" sortable header={t('rbkey_TrnngGrpLBL', 'Nhóm đào tạo')} body={(rowData, column) => decodeUnicode(rowData.VC_GRP_NM)} />
                    <Column field="VC_CRS_NM" sortable header={t('rbkey_CrsNmLBL', 'Tên khóa học')} body={(rowData, column) => decodeUnicode(rowData.VC_CRS_NM)} />
                    <Column field="VC_STRT_DT" sortable header={t('rbkey_StrtDtLBL', 'Ngày bắt đầu')} body={(rowData, column) => decodeUnicode(rowData.VC_STRT_DT)} />
                    <Column field="VC_END_DT" sortable header={t('rbkey_EdDtLBL', 'Ngày Kết thúc')} body={(rowData, column) => decodeUnicode(rowData.VC_END_DT)} />
                    <Column field="NM_CRS_CRDT_HRS" sortable header={t('rbkey_CrdtHrsLBL', 'Giờ tín chỉ')} body={(rowData, column) => decodeUnicode(rowData.NM_CRS_CRDT_HRS)} />
                    <Column field="RB_CRRCLM_TYP_NM" sortable header={t('rbkey_CrsTypLBL', 'Loại khóa học')} body={(rowData, column) => decodeUnicode(rowData.RB_CRRCLM_TYP_NM)} />
                    <Column field="CH_CRS_STTS" sortable header={t('rbkey_TrangsttsLBL', 'Tình trạng đào tạo')} body={(rowData, column) => decodeUnicode(rowData.CH_CRS_STTS)} />
                    <Column field="DT_CMPLTN_DT" sortable header={t('rbkey_CmpltnDtLBL', 'Ngày hoàn thành')} style={{ width: '200px' }} className={'text-center'} body={(rowData, column) => columnBodyDate(rowData.DT_CMPLTN_DT)} />
                    <Column field="NM_PRGRSS" sortable header={t('rbkey_PrcntofcmpltnLBL', 'Phần trăm hoàn thành')} body={(rowData, column) => decodeUnicode(rowData.NM_PRGRSS)} />
                    <Column field="USR_ILT_STTS" sortable header={t('rbkey_UsrNmntnSttsLBL', 'Trạng thái đề xuất người dùng')} body={(rowData, column) => decodeUnicode(rowData.USR_ILT_STTS)} />
                    <Column field="VC_SSN_NM" sortable header={t('rbkey_SssnNmLBL', 'Tên ca học')} body={(rowData, column) => decodeUnicode(rowData.VC_SSN_NM)} />
                    <Column field="VC_ATTNDNC_STTS" sortable header={t('rbkey_SttsPALBL', 'Trạng thái (P / A)')} body={(rowData, column) => decodeUnicode(rowData.VC_ATTNDNC_STTS)} />
                    <Column field="CH_ILT_STTS" sortable header={t('rbkey_SttsCTLBL', 'Trạng thái lớp học')} body={(rowData, column) => decodeUnicode(rowData.CH_ILT_STTS)} />
                    <Column field="VC_FNCTNL_NM" sortable header={t('rbkey_FnctnLBL', 'Chức năng')} body={(rowData, column) => decodeUnicode(rowData.VC_FNCTNL_NM)} />
                    <Column field="VC_VN_NM" sortable header={t('rbkey_TrnngVnLBL', 'Địa điểm tổ chức đào tạo')} body={(rowData, column) => decodeUnicode(rowData.VC_VN_NM)} />
                    <Column field="VC_INSTRCTR_NM" sortable header={t('rbkey_InstrctrLBL', 'Giảng viên')} body={(rowData, column) => decodeUnicode(rowData.VC_INSTRCTR_NM)} />
                    <Column field="VC_RPRTNG_ATHRTY_EML_ADDRSS" sortable header={t('rbkey_RprtngAthrtyEmlIdLBL', 'ID e-mail của người quản lý báo cáo')} body={(rowData, column) => decodeUnicode(rowData.VC_RPRTNG_ATHRTY_EML_ADDRSS)} />
                                </DataTable>
                            </div>
                        </div>
                    </Card>
                </div>
            </Dialog>

            <Card title={titlePage}>
                <Toast ref={toast} />
                <div className='row mb-2 row-button'>
                    <div className="col-12 col-sm-12" style={{ textAlign: 'right' }}>
                        <Permission code={codePermAdd}>   
                        </Permission>

                    <Link to={'/admin/MyTm'}>
                        <Button icon='fa fa-list' label={t('rbkey_MyTmLBL', 'Nhóm của tôi')} />
                    </Link>
                    <Link to={'/admin/DwnldTmRprt'}>
                        <Button icon='fa fa-list' label={t('rbkey_DwnldTmRprtLBL', 'Tải xuống báo cáo nhóm')} />
                    </Link>
                    <Link to={'/admin/PrntCrtfctMngmnt'}>
                        <Button icon='fa fa-list' label={t('rbkey_PrntCrtfctLBL', 'In chứng chỉ')} />
                    </Link>
                    <Link to={'/admin/CrtfctMngmnt'}>
                        <Button icon='fa fa-list' label={t('rbkey_CrtfctLBL', 'Chứng chỉ')} />
                    </Link>
                    </div>
                </div>
                {true && <div className='row mb-2'>
                    <div className="col-12 col-sm-5">
                        <div className="p-inputgroup">
                            <InputText autoFocus placeholder={labelKeyword} onKeyDown={onEnterKeySearch} onChange={(e)=>onChangeKeySearch(e.target.value)} value={lazyParams.keySearch ?? ''} />
                            <Button icon="pi pi-search" className="p-button-outlined p-button-secondary" onClick={()=>onFilter()} />
                            {false && showAdvancedSearchButton && <Button icon={showAdvancedSearch == true ? "fas fa-folder" : "far fa-folder-open"} className="p-button-outlined p-button-secondary" onClick={()=>onShowAdvancedSearch()} 
                            title={labelFind} style={{left: '-1px'}} /> }
                        </div>
                    </div>
                </div>}
                {showAdvancedSearch == true && 
                    <div className='row mb-2 advancedSearchBox'>
                        <div className="col-12 col-sm-12">
                            <h5 className='card-title'>{labelFind}</h5>
                        </div>

                        <div className="col-12 col-sm-4">                        
                            <Button className={'p-button-secondary'} icon='pi pi-search' label={labelFindButton} onClick={()=>onFilter()} />
                            {showAdvancedSearchButton && <Button icon={showAdvancedSearch == true ? "fas fa-folder" : "far fa-folder-open"} className="p-button-outlined p-button-secondary" onClick={()=>onShowAdvancedSearch()} 
                            title={labelFind} style={{left: '-3px'}} /> }
                        </div>
                    </div>  }
            
                <DataTable value={listItems} dataKey={fieldID} emptyMessage={t('rbkey_NRcrdsFndMSG', 'Không có dữ liệu được tìm thấy.')}
                    size="small" lazy responsiveLayout="stack" paginator showGridlines
                    paginatorTemplate="CurrentPageReport FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink"
                    currentPageReportTemplate="{first} - {last} / {totalRecords}"
                    paginatorLeft={paginatorLeft} totalRecords={totalItems} loading={loading} rowsPerPageOptions={DEFAULT_LIST_PAGE} 
                    rows={lazyParams.rows} first={lazyParams.first} sortField={lazyParams.sortField} sortOrder={lazyParams.sortOrder} 
                    onPage={onPage} onSort={onSort} onSelectionChange={onSelectionChange} 
                    selection={selectedItems} selectionMode="checkbox" 
                >
                    <Column className='text-center' style={{ width: '40px' }} body={(rowData, item)=>{
                       return(<>{item.rowIndex + 1}</>)
                    }} header="#" />
                    <Column selectionMode="multiple" headerStyle={{ width: '3em' }}></Column>

                    <Column field="VC_USR_NM" sortable header={t('rbkey_UsrNmLBL', 'Tên tài khoản')} body={(rowData, column) => decodeUnicode(rowData.VC_USR_NM)} />
                    <Column field="VC_EML_ADDRSS" sortable header={t('rbkey_EmlLBL', 'E-mail')} body={(rowData, column) => decodeUnicode(rowData.VC_EML_ADDRSS)} />
                    <Column field="VC_CNTCT_NMBR_MBL" sortable header={t('rbkey_MblNmbrLBL', 'Số điện thoại di động')} body={(rowData, column) => decodeUnicode(rowData.VC_CNTCT_NMBR_MBL)} />
                    <Column field="VC_UIDAI" sortable header={t('rbkey_UdLBL', 'Mã nhân viên')} body={(rowData, column) => decodeUnicode(rowData.VC_UIDAI)} />
                    <Column field="VC_LGN_CD" sortable header={t('rbkey_LgnCdLBL', 'ID Đăng nhập')} body={(rowData, column) => decodeUnicode(rowData.VC_LGN_CD)} />
                    <Column field="VC_RL_NM" sortable header={t('rbkey_PrmryRlLBL', 'Vai trò chính')} body={(rowData, column) => decodeUnicode(rowData.VC_RL_NM)} />
                    <Column field="VC_ACTNS" sortable header={t('rbkey_ActnsLBL', 'Các tác vụ')} body={(rowData, column) => decodeUnicode(rowData.VC_ACTNS)} />

                    <Column style={{ width: '80px' }} className={'text-center'} body={actionBodyTemplate} header={<i className='pi pi-cog'></i>} exportable={false} ></Column>
                </DataTable>
            
                <div className='row mb-2 row-button' style={{ marginTop: '5px' }}>
                    <div className="col-12 col-sm-12">

                    </div>
                </div>
            </Card>
        </>
    )
};
export default MyTmList;
