import React, { useState, useEffect, useRef } from 'react';
import dayjs from 'dayjs';
import utc from 'dayjs/plugin/utc'
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Button } from 'primereact/button';
import { Link } from 'react-router-dom';
import { Dropdown } from 'primereact/dropdown';
import { mapPaginator } from 'shared/utils';
import { useSelector, useDispatch } from 'react-redux';
import { setParamState } from 'store/listParamSlice';
import { decodeUnicode } from 'shared/utils/decodeHtmlEntites';
import { confirmDialogGlobal } from 'shared/components/confirmDialogGlobal';
import { DEFAULT_LIST_PARAM, DEFAULT_LIST_PAGE } from 'shared/app-settings';
import { GC_LICH_HANG_NGAYService  } from 'modules/GC_LICH_HANG_NGAY/GC_LICH_HANG_NGAYService';

dayjs.extend(utc)
const SheetTable = (props) => {
    const openDialog = false;
    const fieldID = 'id';
    const fieldSort = 'id';
    const fieldSortOrder = 'ASC';
    const linkEdit = '/admin/GC_LICH_HANG_NGAY-form';
    const linkView = '/admin/GC_LICH_HANG_NGAY-view';
    const deleteMsg = 'Bạn có chắc chắn xoá bản ghi này không?';
    const columnBodyDate = (date) => {
        return dayjs(date).format('DD/MM/YYYY HH:mm')
    };

    /**/
    const dispatch = useDispatch();
    const listParamStore = useSelector(state => {
        var param = null;
        if(state.listParam.find(st => st && st.name == window.location.toString()))
            param = state.listParam.find(st => st && st.name == window.location.toString()).param;
        return param;
    });
    const [loading, setLoading] = useState(false);
    const [showAdvancedSearch, setShowAdvancedSearch] = useState(false);
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
        // try {
        //     const arr = listItems?.map(item => item.ten_id_nguoi_thuc_hien);
        //     console.log(`list item: ${arr}`);
        // } catch (error) {
        //     console.log("Loi roi!");
        // }
       
    }, [lazyParams.refresh]);
    useEffect(() => {
        setTimeout(() => {
            if(listParamStore && listParamStore.pageYOffset) window.scrollTo(0, listParamStore.pageYOffset);
        }, 100);

        // getListRef_id_nguoi_thuc_hien();
        // getListRef_id_cong_viec();
    }, [window.location.href]);
    const loadLazyData = () => {
        setLoading(true);
        let advanceSearch = mapPaginator(lazyParams);
        return GC_LICH_HANG_NGAYService.filterPage(advanceSearch).then(res => {
            setTotalItems(res.data.meta.total);
            setListItems(res.data.data);
            setLoading(false);
        });
    }

    // const getListRef_id_nguoi_thuc_hien = () => {
    //     return GC_LICH_HANG_NGAYService.getAllRef_id_nguoi_thuc_hien().then(res => {
    //         res.data.map(x => {
    //             x.Value = x.value;
    //             x.Text = x.label;
    //         });
    //         setListRef_id_nguoi_thuc_hien(res.data);
    //     });
    // }
    // const getListRef_id_cong_viec = () => {
    //     return GC_LICH_HANG_NGAYService.getAllRef_id_cong_viec().then(res => {
    //         res.data.map(x => {
    //             x.Value = x.value;
    //             x.Text = x.label;
    //         });
    //         setListRef_id_cong_viec(res.data);
    //     });
    // }
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
    const editItem = async (id) => {
        setSelectedId(id);
        dispatch(setParamState({...lazyParams, pageYOffset: window.pageYOffset}));
        if(openDialog) setShowDialogEdit(true);
    }
    const viewItem = async (id) => {
        setSelectedId(id);
        dispatch(setParamState({...lazyParams, pageYOffset: window.pageYOffset}));
        if(openDialog) setShowDialogView(true);
    }
    const closeDialog = async () => {
        if(openDialog) setShowDialogEdit(false);
        if(openDialog) setShowDialogView(false);
    }
    const deleteItem = async (id) => {
        await GC_LICH_HANG_NGAYService.delete(id);
        loadLazyData();
    }
    const deleteItems = async (items) => {
        for(var i = 0; i < items.length; i++) {
            await GC_LICH_HANG_NGAYService.delete(items[i][fieldID]);
        }
        loadLazyData();
    }
    const confirmDelete = (data) => {
        confirmDialogGlobal({
            message: deleteMsg,
            accept: () => data ? deleteItem(data[fieldID]) : deleteItems(selectedItems),
            rejectClassName: 'btnClose',
            acceptClassName: 'p-button-danger'
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
                    <Link to={openDialog ? null : linkEdit + '/' + rowData[fieldID]} onClick={() => editItem(rowData[fieldID])}><i className="p-button-rounded p-button p-button-text p-1 pi pi-pencil mr-2 flex align-items-center"></i></Link>
                    <Link to={openDialog ? null : linkView + '/' + rowData[fieldID]} onClick={() => viewItem(rowData[fieldID])}><i className="p-button-rounded p-button p-button-text p-1 pi pi-info-circle mr-2 flex align-items-center"></i></Link>
                    <a onClick={() => confirmDelete(rowData)}><i className="p-button-rounded p-button p-button-text p-1 pi pi-trash mr-2 flex align-items-center p-button-danger p-button-outlined"></i></a>
                </div>
            </React.Fragment>
        );  
    }
    /**/   
    return (
      
            
            <DataTable value={listItems} dataKey={fieldID} emptyMessage={'Không có kết quả'}
                size="small" lazy responsiveLayout="stack" paginator showGridlines
                paginatorTemplate="CurrentPageReport FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink"
                currentPageReportTemplate="{first} - {last} / {totalRecords}"
                paginatorLeft={paginatorLeft} totalRecords={totalItems} loading={loading} rowsPerPageOptions={DEFAULT_LIST_PAGE} 
                rows={lazyParams.rows} first={lazyParams.first} sortField={lazyParams.sortField} sortOrder={lazyParams.sortOrder} 
                onPage={onPage} onSort={onSort} onSelectionChange={onSelectionChange} 
                // selection={selectedItems} selectionMode="checkbox" 
            >
                <Column className='text-center' style={{ width: '40px' }} body={(rowData, item)=>{
                   return(<>{item.rowIndex + 1}</>)
                }} header="#" />
                {/* <Column selectionMode="multiple" headerStyle={{ width: '3em' }}></Column>  */}

                <Column field="id_nguoi_thuc_hien" sortable header={'Nhân viên'} body={(rowData, column) => decodeUnicode(rowData.ten_id_nguoi_thuc_hien)} />
                <Column field="id_cong_viec" sortable header={'Công việc'} body={(rowData, column) => decodeUnicode(rowData.ten_id_cong_viec)} />
                <Column style={{ width: '200px' }} className={'text-center'} field="ngay_lam_viec" body={(rowData, column) => columnBodyDate(rowData.ngay_lam_viec)} header={'ngay_lam_viec'} />
                <Column style={{ width: '200px' }} className={'text-center'} field="ngay_checkin" body={(rowData, column) => columnBodyDate(rowData.ngay_checkin)} header={'ngay_checkin'} />
                <Column style={{ width: '200px' }} className={'text-center'} field="ngay_checkout" body={(rowData, column) => columnBodyDate(rowData.ngay_checkout)} header={'ngay_checkout'} />
                <Column field="so_gio" sortable header={'Số giờ'} body={(rowData, column) => decodeUnicode(rowData.so_gio)} />
                <Column field="nguoi_tao_id" sortable header={'Title of nguoi_tao_id'} body={(rowData, column) => decodeUnicode(rowData.nguoi_tao_id)} />
                <Column style={{ width: '200px' }} className={'text-center'} field="ngay_tao" body={(rowData, column) => columnBodyDate(rowData.ngay_tao)} header={'ngay_tao'} />
                <Column field="nguoi_chinh_sua_id" sortable header={'Title of nguoi_chinh_sua_id'} body={(rowData, column) => decodeUnicode(rowData.nguoi_chinh_sua_id)} />
                <Column style={{ width: '200px' }} className={'text-center'} field="ngay_chinh_sua" body={(rowData, column) => columnBodyDate(rowData.ngay_chinh_sua)} header={'ngay_chinh_sua'} />

                <Column style={{ width: '80px' }} className={'text-center'} body={actionBodyTemplate} header={<i className='pi pi-cog'></i>} exportable={false} ></Column> 
            </DataTable>
    )
};
export default SheetTable;

