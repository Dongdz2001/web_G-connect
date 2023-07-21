import React, { useState, useEffect, useRef } from 'react';
import dayjs from 'dayjs';
import utc from 'dayjs/plugin/utc'
import { Card } from 'primereact/card';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Button } from 'primereact/button';
import { InputText } from 'primereact/inputtext';
import { Link } from 'react-router-dom';
import { Dropdown } from 'primereact/dropdown';
import { Toast } from 'primereact/toast';
import { useTranslation } from 'react-i18next'
import { mapPaginator } from 'shared/utils';
import Permission from 'components/Permission';
import { Calendar } from 'components/Calendar';
import { locationService  } from 'modules/location/locationService';
import { confirmDialogGlobal } from 'shared/components/confirmDialogGlobal';
import { useSelector, useDispatch } from 'react-redux';
import { setParamState } from 'store/listParamSlice';
import { DEFAULT_LIST_PARAM, DEFAULT_LIST_PAGE } from 'shared/app-settings';
dayjs.extend(utc)
const LocationList = () => {
    const { t, i18n } = useTranslation();
    const fieldID = 'NM_LCTN_ID';
    const fieldSort = 'VC_LCTN_NM';
    const fieldSortOrder = 'ASC';
    const linkEdit = '/admin/location-form';
    const showAdvancedSearchButton = true;
    const codeAdd = 'USER_ADD';
    const deleteMsg = t('rbkey_IsRprtn2gAthrtyDltMSG', 'Bạn có chắc chắn xoá bản ghi này không?');
    const titlePage = t('rbkey_ct_ov111rvw', 'Danh sách vị trí');
    const labelAdd = t('rbkey_ct_ov111rvw', 'Thêm vị trí');
    const labelDelete = t('rbkey_ct_ov111rvw', 'Xóa vị trí');
    const labelKeyword = t('rbkey_ct_ov111rvw', 'Từ khoá...');
    const labelFind = t('rbkey_ct_ov111rvw', 'Tìm kiếm nâng cao');
    const labelFindButton = t('rbkey_ct_ov111rvw', 'Tìm kiếm');
    const columnBodyDate = (date) => {
        return dayjs(date).format('DD/MM/YYYY HH:mm')
    };
    const columnBodyState = (rowData) => {
        if (rowData) {
            return (<i className='pi pi-lock' title={t('rbkey_ct_ov111rvw', 'Bị khoá')}></i>)
        } else return (<>Good</>)
    }
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
        return locationService.filterPage(advanceSearch).then(res => {
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
        await userService.delete(id);
        loadLazyData();
    }
    const deleteItems = async (items) => {
        for(var i = 0; i < items.length; i++) {
            await userService.delete(items[i][fieldID]);
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
                    <Link to={linkEdit + '/' + rowData[fieldID]} onClick={() => editItem()}><i className="p-button-rounded p-button p-button-text p-1 pi pi-pencil mr-2 flex align-items-center"></i></Link>
                    <a onClick={() => confirmDelete(rowData)}><i className="p-button-rounded p-button p-button-text p-1 pi pi-trash mr-2 flex align-items-center p-button-danger p-button-outlined"></i></a>
                </div>
            </React.Fragment>
        );  
    }
    /**/   
    return (
        <Card title={titlePage}>
            <Toast ref={toast} />
            <div className='row mb-2'>
                <div className="col-12 col-sm-7">
                    <Permission code={codeAdd}>
                        
                    </Permission>
                    <Link to={linkEdit + '/new'}>
                        <Button icon='fa fa-plus' label={labelAdd} />
                    </Link>
                    {selectedItems?.length >= 0 ? 
                        <Button className={'p-button-outlined ' + (selectedItems?.length == 0 ? 'p-button-secondary p-disabled' : 'p-button-danger')} disabled={selectedItems?.length == 0} icon='pi pi-trash' label={labelDelete} onClick={()=>confirmDelete()} style={{marginLeft: '5px'}} />
                        : null }
                </div>
                <div className="col-12 col-sm-5">
                    <div className="p-inputgroup">
                        <InputText autoFocus placeholder={labelKeyword} onKeyDown={onEnterKeySearch} onChange={(e)=>onChangeKeySearch(e.target.value)} value={lazyParams.keySearch ?? ''} />
                        <Button icon="pi pi-search" className="p-button-outlined p-button-secondary" onClick={()=>onFilter()} />
                        {showAdvancedSearchButton && <Button icon={showAdvancedSearch == true ? "fas fa-folder" : "far fa-folder-open"} className="p-button-outlined p-button-secondary" onClick={()=>onShowAdvancedSearch()} 
                        title={labelFind} /> }
                    </div>
                </div>
            </div>
            {showAdvancedSearch == true && 
                <div className='row mb-2'>
                    <div className="col-12 col-sm-12">
                        <h5 className='card-title'>{labelFind}</h5>
                    </div>
                    <div className="col-12 col-sm-2">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <Calendar
                                    className='mr-2'
                                    showButtonBar={true}
                                    dateFormat="dd/mm/yy"
                                    id="from_date"
                                    value={lazyParams.from_date ? (dayjs(lazyParams.from_date).$d ?? null) : null}
                                    onChange={(e)=>{
                                        setLazyParams({
                                            ...lazyParams,
                                            from_date: e.value?.toLocaleDateString().slice(0, 10) ?? '',
                                        });
                                    }}
                                    mask="99/99/9999"
                                    showIcon
                                    placeholder='Từ ngày'
                                    />
                                <label htmlFor="from_date" >{t('rbkey_ct_ov111rvw', 'Từ ngày')}</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-2">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <i className="pi pi1-envelope" />
                                <InputText name="UserEmail" onChange={(e)=>setLazyParams({
                                    ...lazyParams,
                                    keySearch: e.target.value,
                                })} value={lazyParams.keySearch ?? ''} />
                                <label htmlFor="UserEmail" >{labelKeyword}</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-4">                        
                        <Button className={'p-button-secondary'} icon='pi pi-search' label={labelFindButton} onClick={()=>onFilter()} />
                        {showAdvancedSearchButton && <Button icon={showAdvancedSearch == true ? "fas fa-folder" : "far fa-folder-open"} className="p-button-outlined p-button-secondary" onClick={()=>onShowAdvancedSearch()} 
                        title={labelFind} /> }
                    </div>
                </div>  }
            
            <DataTable value={listItems} dataKey={fieldID} emptyMessage={t('rbkey_ct_ov111rvw', 'Không có kết quả')}
                size="small" lazy responsiveLayout="stack" paginator showGridlines
                paginatorTemplate="CurrentPageReport FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink"
                currentPageReportTemplate="{first} - {last} / {totalRecords}"
                paginatorLeft={paginatorLeft} totalRecords={totalItems} loading={loading} rowsPerPageOptions={DEFAULT_LIST_PAGE} 
                rows={lazyParams.rows} first={lazyParams.first} sortField={lazyParams.sortField} sortOrder={lazyParams.sortOrder} 
                onPage={onPage} onSort={onSort} onSelectionChange={onSelectionChange} 
                selection={selectedItems} selectionMode="checkbox" 
            >
                <Column className='text-center' style={{ width: '40px' }} body={(rowData, item)=>{
                   return(<>{item.rowIndex +1}</>)
                }} header="#" />
                <Column selectionMode="multiple" headerStyle={{ width: '3em' }}></Column>

                <Column field="VC_LCTN_NM" sortable header={t('rbkey_ct_ov111rvw', 'Vị trí')} />
                <Column field="VC_LCTN_CD" sortable header={t('rbkey_ct_ov111rvw', 'Mã vị trí')} />                
                <Column style={{ width: '200px' }} field="DT_CRTN_DT" body={(rowData, column) => columnBodyDate(rowData.created_at_utc)} header={t('rbkey_ct_ov111rvw', 'Ngày tạo')} />
                <Column style={{ width: '200px' }} field="DT_CRTN_DT" body={(rowData, column) => columnBodyDate(rowData.created_at_utc)} header={t('rbkey_ct_ov111rvw', 'Ngày sửa đổi')} className={'tdCenter'} />

                <Column style={{ width: '80px' }} className={'tdCenter'} body={actionBodyTemplate} header={<i className='pi pi-cog'></i>} exportable={false} ></Column>
            </DataTable>
        </Card>
    )
};
export default LocationList;