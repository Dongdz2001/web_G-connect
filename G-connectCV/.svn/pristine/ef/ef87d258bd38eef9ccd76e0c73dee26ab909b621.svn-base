import React, { useState, useEffect } from 'react';
import { Card } from 'primereact/card';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Button } from 'primereact/button';
import { Link } from 'react-router-dom';
import { mapPaginator } from 'shared/utils';
import dayjs from 'dayjs';
import { Image } from 'components/Image';
import { appSetting } from 'shared/app-settings';
import { confirmDialog } from 'primereact/confirmdialog';
import { BaseService  } from 'services/BaseService';
import { InputText } from 'primereact/inputtext';
import { postStatusText, ACTIVE, DEACTIVE } from 'shared/utils/appState';
import { Tag } from 'components/tag';
const PostList = () => {
    const [loading, setLoading] = useState(false);
    const [totalRecords, setTotalRecords] = useState(0);
    const [items, setItems] = useState(null);
    const [lazyParams, setLazyParams] = useState({
        first: 0,
        rows: 20,
        page: 0,
        sortField: 'created_at_utc',
        sortOrder: true,
        filters: {
            'name': { value: '', matchMode: 'contains' },
            'country.name': { value: '', matchMode: 'contains' },
            'company': { value: '', matchMode: 'contains' },
            'representative.name': { value: '', matchMode: 'contains' },
        }
    });
    useEffect(() => {
        loadLazyData();
    }, [lazyParams])
    const loadLazyData = () => {
        setLoading(true);
        let advanceSearch = mapPaginator(lazyParams);

    }
    const onPage = (event) => {
        setLazyParams(event);
    }
    const onSort = (event) => {
        setLazyParams(event);
    }


    const onSelectionChange = (event) => {
        const value = event.value;
        setSelectedCustomers(value);
        setSelectAll(value.length === totalRecords);
    }


    const paginatorLeft = <Button type="button" icon="pi pi-refresh" className="p-button-text" onClick={() => loadLazyData()} />;
    const columnCreatedDate = (rowData, column) => {

        return dayjs(rowData.created_at_utc).format('DD/MM/YYYY HH:mm:ss')
    }
    const actionBodyTemplate = (rowData) => {
        return (
            <React.Fragment>
                <div className='flex flex-row justify-content-end' >
                    <Link to={'/admin/post-form/' + rowData.id}><i className="p-button-rounded p-button p-button-text p-1 pi pi-pencil mr-2 flex align-items-center"></i></Link>
                    <a onClick={() => confirmDelete(rowData)}><i className="p-button-rounded p-button p-button-text p-1 pi pi-trash mr-2 flex align-items-center"></i></a>
                </div>

            </React.Fragment>
        );
    }
    const stateBody = (rowData) => {
        if (rowData.state) {
            return (<i className='pi pi-lock' title='Bị khoá'></i>)
        } else return (<></>)

    }
    const columnBodyAvatar = (rowData) => {
        return (<Image width='80' src={'data:image/jpeg;base64,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'} />)
    }
    const deleteItem = async (id) => {
        loadLazyData();
    }
    const confirmDelete = (data) => {
        confirmDialog({
            message: 'Bạn có chắc chắn xoá bản ghi này không?',
            header: 'Delete Confirmation',
            icon: 'pi pi-info-circle',
            acceptClassName: 'p-button-danger',
            accept: () => deleteItem(data.id)
        });
    };
    const onEnterKeySearch = (e) => {
        if (e.key === 'Enter') {
            loadLazyData();
        }
    }
    const onChangeKeySearch = (text) => {
        setLazyParams((state) => {
            state.key_search = text;
            return state;
        });
    }
    return (
        <Card title="Bài viết">
            <div className='row mb-2'>
                <div className="col-4 col-sm-8">

                    <Link to={'/admin/post-form/new'}><Button icon='fa fa-plus' label='Thêm mới' />
                    </Link>

                </div>
                <div className="col-8 col-sm-4">
                    <div className="p-inputgroup">
                        <InputText autoFocus placeholder="Từ khoá..." onKeyDown={onEnterKeySearch} onChange={(e) => onChangeKeySearch(e.target.value)} />
                        <Button icon="pi pi-search" className="p-button-outlined p-button-secondary" onClick={()=>loadLazyData()}/>
                    </div>
                </div>
            </div>

            <DataTable showGridlines  size="small" value={items} lazy responsiveLayout="stack" dataKey="id"
                paginator paginatorTemplate="CurrentPageReport FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink"
                currentPageReportTemplate="{first} - {last} / {totalRecords}" rows={lazyParams.rows} rowsPerPageOptions={[10, 20, 50]}
                paginatorLeft={paginatorLeft} first={lazyParams.first} totalRecords={totalRecords} onPage={onPage}
                onSort={onSort} sortField={lazyParams.sortField} sortOrder={lazyParams.sortOrder}
                loading={loading}
                onSelectionChange={onSelectionChange}

            >
                <Column className='text-center' style={{ width: '40px' }} body={(rowData, item)=>{
                   return(<>{item.rowIndex +1}</>)
                }} header="#" />
                <Column style={{ width: '100px' }} field="avatar" header="Ảnh đại diện" body={columnBodyAvatar} />
                <Column field="VC_FRST_NM" sortable header="Tiêu đề" />
                <Column field="summary" sortable header="Mô tả" />
                <Column style={{ width: '150px' }} field="created_at_utc" body={columnCreatedDate} sortable header="Ngày tạo" />
                <Column style={{ width: '10%' }} field="state" body={(rowData)=>{
                    let severity = ''
                    if(rowData.state==ACTIVE )severity='success';
                    if(rowData.state==DEACTIVE )severity='warning';
                    return(<Tag severity={severity} value={rowData.VC_LGN_CD} />)
                }} sortable header="Trạng thái" />
                <Column style={{ width: '80px' }} body={actionBodyTemplate} header={<i className='pi pi-cog'></i>} exportable={false} ></Column>
            </DataTable>
        </Card>
    )
};
export default PostList;