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
import { useTranslation } from 'react-i18next'
import { mapPaginator } from 'shared/utils';
import Permission from 'components/Permission';
import { Calendar } from 'components/Calendar';
import { useSelector, useDispatch } from 'react-redux';
import { setParamState } from 'store/listParamSlice';
import { decodeUnicode } from 'shared/utils/decodeHtmlEntites';
import { confirmDialogGlobal } from 'shared/components/confirmDialogGlobal';
import { DEFAULT_LIST_PARAM, DEFAULT_LIST_PAGE } from 'shared/app-settings';

import { qtht_don_viService  } from 'modules/qtht_don_vi/qtht_don_viService';

dayjs.extend(utc)
const qtht_don_viList = () => {
    const { t, i18n } = useTranslation();
    const fieldID = 'id';
    const fieldSort = 'id';
    const fieldSortOrder = 'ASC';
    const linkEdit = '/admin/qtht_don_vi-form';
    const showAdvancedSearchButton = true;
    const codePermAdd = 'PERM_qtht_don_vi_ADD';
    const codePermModify = 'PERM_qtht_don_vi_MOD';
    const codePermDel = 'PERM_qtht_don_vi_DEL';
    const deleteMsg = 'Bạn có chắc chắn xoá bản ghi này không?';
    const titlePage = 'Danh sách Title of qtht_don_vi';
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

    const [listRef_nguoi_tao_id, setListRef_nguoi_tao_id] = useState([]);
    const [listRef_nguoi_chinh_sua_id, setListRef_nguoi_chinh_sua_id] = useState([]);
    const [listRef_don_vi_cap_tren_id, setListRef_don_vi_cap_tren_id] = useState([]);
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

        getListRef_nguoi_tao_id();
        getListRef_nguoi_chinh_sua_id();
        getListRef_don_vi_cap_tren_id();
    }, [window.location.href]);
    const loadLazyData = () => {
        setLoading(true);
        console.log(lazyParams)
        let advanceSearch = mapPaginator(lazyParams);
        return qtht_don_viService.filterPage(advanceSearch).then(res => {
            setTotalItems(res.data.TotalRecords);
            setListItems(res.data.Data);
            setLoading(false);
        });
    }

    const getListRef_nguoi_tao_id = () => {
        return qtht_don_viService.getAllRef_nguoi_tao_id().then(res => {
            res.data.map(x => {
                x.Value = x.ID;
                x.Text = x.NAME;
            });
            setListRef_nguoi_tao_id(res.data);
        });
    }
    const getListRef_nguoi_chinh_sua_id = () => {
        return qtht_don_viService.getAllRef_nguoi_chinh_sua_id().then(res => {
            res.data.map(x => {
                x.Value = x.ID;
                x.Text = x.NAME;
            });
            setListRef_nguoi_chinh_sua_id(res.data);
        });
    }
    const getListRef_don_vi_cap_tren_id = () => {
        return qtht_don_viService.getAllRef_don_vi_cap_tren_id().then(res => {
            res.data.map(x => {
                x.Value = x.ID;
                x.Text = x.NAME;
            });
            setListRef_don_vi_cap_tren_id(res.data);
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
                    <Permission code={codePermAdd}>
                        
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
                        title={labelFind} style={{left: '-1px'}} /> }
                    </div>
                </div>
            </div>
            {showAdvancedSearch == true && 
                <div className='row mb-2 advancedSearchBox'>
                    <div className="col-12 col-sm-12">
                        <h5 className='card-title'>{labelFind}</h5>
                    </div>

                    <div className="col-12 col-sm-4">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <i className="pi pi1-envelope" />
                                    <Dropdown options={listRef_nguoi_tao_id} optionValue='Value' optionLabel='Text' scrollHeight={'600px'} className=''
                                        value={lazyParams.nguoi_tao_id}
                                        onChange={(e)=>{
                                            setLazyParams({
                                                ...lazyParams,
                                                nguoi_tao_id: e.value,
                                            });
                                        }}
                                        placeholder='--Chọn--'
                                        showClear
                                    />
                                <label htmlFor="nguoi_tao_id" >Title of nguoi_tao_id</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-2">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <Calendar
                                    className=''
                                    showButtonBar={true}
                                    dateFormat="dd/mm/yy"
                                    id="ngay_tao"
                                    value={lazyParams.ngay_tao ? (dayjs(lazyParams.ngay_tao).$d ?? null) : null}
                                    onChange={(e)=>{
                                        setLazyParams({
                                            ...lazyParams,
                                            ngay_tao: e.value?.toLocaleDateString().slice(0, 10) ?? '',
                                        });
                                    }}
                                    mask="99/99/9999"
                                    showIcon
                                    placeholder='Title of ngay_tao'
                                    />
                                <label htmlFor="ngay_tao" >{'Title of ngay_tao'}</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-4">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <i className="pi pi1-envelope" />
                                    <Dropdown options={listRef_nguoi_chinh_sua_id} optionValue='Value' optionLabel='Text' scrollHeight={'600px'} className=''
                                        value={lazyParams.nguoi_chinh_sua_id}
                                        onChange={(e)=>{
                                            setLazyParams({
                                                ...lazyParams,
                                                nguoi_chinh_sua_id: e.value,
                                            });
                                        }}
                                        placeholder='--Chọn--'
                                        showClear
                                    />
                                <label htmlFor="nguoi_chinh_sua_id" >Title of nguoi_chinh_sua_id</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-2">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <Calendar
                                    className=''
                                    showButtonBar={true}
                                    dateFormat="dd/mm/yy"
                                    id="ngay_chinh_sua"
                                    value={lazyParams.ngay_chinh_sua ? (dayjs(lazyParams.ngay_chinh_sua).$d ?? null) : null}
                                    onChange={(e)=>{
                                        setLazyParams({
                                            ...lazyParams,
                                            ngay_chinh_sua: e.value?.toLocaleDateString().slice(0, 10) ?? '',
                                        });
                                    }}
                                    mask="99/99/9999"
                                    showIcon
                                    placeholder='Title of ngay_chinh_sua'
                                    />
                                <label htmlFor="ngay_chinh_sua" >{'Title of ngay_chinh_sua'}</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-4">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <i className="pi pi1-envelope" />
                                <InputText name="ten" onChange={(e)=>setLazyParams({
                                    ...lazyParams,
                                    ten: e.target.value,
                                })} value={lazyParams.ten ?? ''} />
                                <label htmlFor="ten" >Title of ten</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-4">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <i className="pi pi1-envelope" />
                                <InputText name="dai_dien" onChange={(e)=>setLazyParams({
                                    ...lazyParams,
                                    dai_dien: e.target.value,
                                })} value={lazyParams.dai_dien ?? ''} />
                                <label htmlFor="dai_dien" >Title of dai_dien</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-4">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <i className="pi pi1-envelope" />
                                <InputText name="dia_chi" onChange={(e)=>setLazyParams({
                                    ...lazyParams,
                                    dia_chi: e.target.value,
                                })} value={lazyParams.dia_chi ?? ''} />
                                <label htmlFor="dia_chi" >Title of dia_chi</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-4">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <i className="pi pi1-envelope" />
                                <InputText name="truc_thuoc" onChange={(e)=>setLazyParams({
                                    ...lazyParams,
                                    truc_thuoc: e.target.value,
                                })} value={lazyParams.truc_thuoc ?? ''} />
                                <label htmlFor="truc_thuoc" >Title of truc_thuoc</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-4">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <i className="pi pi1-envelope" />
                                <InputText name="dien_thoai" onChange={(e)=>setLazyParams({
                                    ...lazyParams,
                                    dien_thoai: e.target.value,
                                })} value={lazyParams.dien_thoai ?? ''} />
                                <label htmlFor="dien_thoai" >Title of dien_thoai</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-4">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <i className="pi pi1-envelope" />
                                <InputText name="mo_ta" onChange={(e)=>setLazyParams({
                                    ...lazyParams,
                                    mo_ta: e.target.value,
                                })} value={lazyParams.mo_ta ?? ''} />
                                <label htmlFor="mo_ta" >Title of mo_ta</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-4">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <i className="pi pi1-envelope" />
                                    <Dropdown options={listRef_don_vi_cap_tren_id} optionValue='Value' optionLabel='Text' scrollHeight={'600px'} className=''
                                        value={lazyParams.don_vi_cap_tren_id}
                                        onChange={(e)=>{
                                            setLazyParams({
                                                ...lazyParams,
                                                don_vi_cap_tren_id: e.value,
                                            });
                                        }}
                                        placeholder='--Chọn--'
                                        showClear
                                    />
                                <label htmlFor="don_vi_cap_tren_id" >Title of don_vi_cap_tren_id</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-4">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <i className="pi pi1-envelope" />
                                <InputText name="cap_don_vi" onChange={(e)=>setLazyParams({
                                    ...lazyParams,
                                    cap_don_vi: e.target.value,
                                })} value={lazyParams.cap_don_vi ?? ''} />
                                <label htmlFor="cap_don_vi" >Title of cap_don_vi</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-4">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <i className="pi pi1-envelope" />
                                <InputText name="muc_luc" onChange={(e)=>setLazyParams({
                                    ...lazyParams,
                                    muc_luc: e.target.value,
                                })} value={lazyParams.muc_luc ?? ''} />
                                <label htmlFor="muc_luc" >Title of muc_luc</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-4">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <i className="pi pi1-envelope" />
                                <InputText name="ma" onChange={(e)=>setLazyParams({
                                    ...lazyParams,
                                    ma: e.target.value,
                                })} value={lazyParams.ma ?? ''} />
                                <label htmlFor="ma" >Title of ma</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-4">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <i className="pi pi1-envelope" />
                                <InputText name="ten_day_du" onChange={(e)=>setLazyParams({
                                    ...lazyParams,
                                    ten_day_du: e.target.value,
                                })} value={lazyParams.ten_day_du ?? ''} />
                                <label htmlFor="ten_day_du" >Title of ten_day_du</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-4">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <i className="pi pi1-envelope" />
                                <InputText name="loai" onChange={(e)=>setLazyParams({
                                    ...lazyParams,
                                    loai: e.target.value,
                                })} value={lazyParams.loai ?? ''} />
                                <label htmlFor="loai" >Title of loai</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-4">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <i className="pi pi1-envelope" />
                                <InputText name="dia_chi_kbnn" onChange={(e)=>setLazyParams({
                                    ...lazyParams,
                                    dia_chi_kbnn: e.target.value,
                                })} value={lazyParams.dia_chi_kbnn ?? ''} />
                                <label htmlFor="dia_chi_kbnn" >Title of dia_chi_kbnn</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-4">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <i className="pi pi1-envelope" />
                                <InputText name="tai_khoan" onChange={(e)=>setLazyParams({
                                    ...lazyParams,
                                    tai_khoan: e.target.value,
                                })} value={lazyParams.tai_khoan ?? ''} />
                                <label htmlFor="tai_khoan" >Title of tai_khoan</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-4">
                        <div className="field">
                            <span className="p-float-label p-input-icon-right">
                                <i className="pi pi1-envelope" />
                                <InputText name="ma_order" onChange={(e)=>setLazyParams({
                                    ...lazyParams,
                                    ma_order: e.target.value,
                                })} value={lazyParams.ma_order ?? ''} />
                                <label htmlFor="ma_order" >Title of ma_order</label>
                            </span>
                        </div>
                    </div>
                    <div className="col-12 col-sm-4">                        
                        <Button className={'p-button-secondary'} icon='pi pi-search' label={labelFindButton} onClick={()=>onFilter()} />
                        {showAdvancedSearchButton && <Button icon={showAdvancedSearch == true ? "fas fa-folder" : "far fa-folder-open"} className="p-button-outlined p-button-secondary" onClick={()=>onShowAdvancedSearch()} 
                        title={labelFind} style={{left: '-3px'}} /> }
                    </div>
                </div>  }
            
            <DataTable value={listItems} dataKey={fieldID} emptyMessage={'Không có kết quả'}
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

                <Column field="ten_nguoi_tao_id" sortable header={'Title of nguoi_tao_id'} body={(rowData, column) => decodeUnicode(rowData.ten_nguoi_tao_id)} />
                <Column style={{ width: '200px' }} className={'text-center'} field="ngay_tao" body={(rowData, column) => columnBodyDate(rowData.ngay_tao)} header={'ngay_tao'} />
                <Column field="ten_nguoi_chinh_sua_id" sortable header={'Title of nguoi_chinh_sua_id'} body={(rowData, column) => decodeUnicode(rowData.ten_nguoi_chinh_sua_id)} />
                <Column style={{ width: '200px' }} className={'text-center'} field="ngay_chinh_sua" body={(rowData, column) => columnBodyDate(rowData.ngay_chinh_sua)} header={'ngay_chinh_sua'} />
                <Column field="ten" sortable header={'Title of ten'} body={(rowData, column) => decodeUnicode(rowData.ten)} />
                <Column field="dai_dien" sortable header={'Title of dai_dien'} body={(rowData, column) => decodeUnicode(rowData.dai_dien)} />
                <Column field="dia_chi" sortable header={'Title of dia_chi'} body={(rowData, column) => decodeUnicode(rowData.dia_chi)} />
                <Column field="truc_thuoc" sortable header={'Title of truc_thuoc'} body={(rowData, column) => decodeUnicode(rowData.truc_thuoc)} />
                <Column field="dien_thoai" sortable header={'Title of dien_thoai'} body={(rowData, column) => decodeUnicode(rowData.dien_thoai)} />
                <Column field="mo_ta" sortable header={'Title of mo_ta'} body={(rowData, column) => decodeUnicode(rowData.mo_ta)} />
                <Column field="ten_don_vi_cap_tren_id" sortable header={'Title of don_vi_cap_tren_id'} body={(rowData, column) => decodeUnicode(rowData.ten_don_vi_cap_tren_id)} />
                <Column field="cap_don_vi" sortable header={'Title of cap_don_vi'} body={(rowData, column) => decodeUnicode(rowData.cap_don_vi)} />
                <Column field="muc_luc" sortable header={'Title of muc_luc'} body={(rowData, column) => decodeUnicode(rowData.muc_luc)} />
                <Column field="ma" sortable header={'Title of ma'} body={(rowData, column) => decodeUnicode(rowData.ma)} />
                <Column field="ten_day_du" sortable header={'Title of ten_day_du'} body={(rowData, column) => decodeUnicode(rowData.ten_day_du)} />
                <Column field="loai" sortable header={'Title of loai'} body={(rowData, column) => decodeUnicode(rowData.loai)} />
                <Column field="dia_chi_kbnn" sortable header={'Title of dia_chi_kbnn'} body={(rowData, column) => decodeUnicode(rowData.dia_chi_kbnn)} />
                <Column field="tai_khoan" sortable header={'Title of tai_khoan'} body={(rowData, column) => decodeUnicode(rowData.tai_khoan)} />
                <Column field="ma_order" sortable header={'Title of ma_order'} body={(rowData, column) => decodeUnicode(rowData.ma_order)} />

                <Column style={{ width: '80px' }} className={'text-center'} body={actionBodyTemplate} header={<i className='pi pi-cog'></i>} exportable={false} ></Column>
            </DataTable>
        </Card>
    )
};
export default qtht_don_viList;

