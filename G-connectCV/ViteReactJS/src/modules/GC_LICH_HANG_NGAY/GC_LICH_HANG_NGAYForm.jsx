import React, { useEffect, useState, useRef } from 'react';
import { useForm, Controller } from 'react-hook-form';
import { InputText } from 'primereact/inputtext';
import { InputTextarea } from 'primereact/inputtextarea';
import { Button } from 'primereact/button';
import CkEditor from 'components/ckeditor4/CkEditor';
import { postStatusText, statusText, ACTIVE, DEACTIVE } from 'shared/utils/appState';
import { SelectImgItem } from 'components/SelectImgItem';
import { Checkbox } from "primereact/checkbox";
import { SelectButton } from 'primereact/selectbutton';
import { AutoComplete } from 'primereact/autocomplete';
import { Calendar } from 'components/Calendar';
import { Dialog } from 'primereact/dialog';
import { classNames } from 'primereact/utils';
import { Card } from 'primereact/card';
import { useParams } from 'react-router-dom';
import { InputSwitch } from 'primereact/inputswitch';
import { Dropdown } from 'primereact/dropdown';
import { useNavigate } from "react-router-dom";
import { useTranslation } from 'react-i18next'
import { decodeUnicode } from 'shared/utils/decodeHtmlEntites';
import { Link } from "react-router-dom";
import moment from "moment";
import "moment/locale/vi";
moment.locale("vi");

import getFormErrorMessage from 'shared/components/getFormErrorMessage';
import { getCurrentUserDefault } from "shared/utils/getCurrentUserDefault";
import sessionStorage from 'redux-persist/es/storage/session';

import { GC_LICH_HANG_NGAYService } from 'modules/GC_LICH_HANG_NGAY/GC_LICH_HANG_NGAYService';

const GC_LICH_HANG_NGAYForm = (props) => {
    const { t, i18n } = useTranslation();
    let { id } = useParams();
    let itemId = props.id ?? id;
    const linkList = '/admin/GC_LICH_HANG_NGAY';
    const labelSave = 'Lưu';
    const labelClose = 'Đóng';
    const itemService = GC_LICH_HANG_NGAYService;
    const dialogFooter = <div className="flex justify-content-center"><Button label="OK" className="p-button-text" autoFocus onClick={() => setShowMessage(false)} /></div>;
    /* */
    let navigate = useNavigate();
    const defaultValues = {
    }
    const [formData, setFormData] = useState({});
    const [showMessage, setShowMessage] = useState(false);

    const [listRef_id_nguoi_thuc_hien, setListRef_id_nguoi_thuc_hien] = useState([]);
    const [listRef_id_cong_viec, setListRef_id_cong_viec] = useState([]);
    const { register, control, formState: { errors }, handleSubmit, reset, watch, getValues, setValue } = useForm({ defaultValues });
    const getFormErrorMessage = (name) => {
        return errors[name] && <small className="p-error">{errors[name].message}</small>
    };
    const userId = getCurrentUserDefault().id;
    const is_super_admin = getCurrentUserDefault().super_admin;
    //setValue({id_nguoi_thuc_hien:userId}); //, ngay_lam_viec: Date.now()

    const [timeIn, setTimeIn] = useState(null);
    const [timeOut, setTimeOut] = useState(null);
    const onSubmit = async (formData) => {
        // console.log(formData);
        if(itemId === 'new'){
            await itemService.create(formData);
        } else {
            await itemService.update(itemId, formData);
        }
        if(props.fnLoadData) props.fnLoadData();
        if(props.fnClose) props.fnClose();
        else navigate(linkList);
    }
    const getById = async (itemId)=>{
        if(itemId==='new') {
            reset({id_nguoi_thuc_hien:userId, id_cong_viec: props.item.id_cong_viec, ngay_lam_viec: moment(Date.now()) });
        }
        else {
            let result = await itemService.getById(itemId);        
            reset(result.data);
        }
    }
    useEffect(() => {
        //if(itemId !=='new') getById(itemId);
        getById(itemId);
        getListRef_id_nguoi_thuc_hien();
        getListRef_id_cong_viec();
    },[window.location.href]);

    const getListRef_id_nguoi_thuc_hien = () => {
        return GC_LICH_HANG_NGAYService.getAllRef_id_nguoi_thuc_hien().then(res => {
            res.data.map(x => {
                x.Value = x.value;
                x.Text = x.label;
            });
            setListRef_id_nguoi_thuc_hien(res.data);
        });
    }
    const getListRef_id_cong_viec = () => {
        return GC_LICH_HANG_NGAYService.getAllRef_id_cong_viec().then(res => {
            res.data.map(x => {
                x.Value = x.value;
                x.Text = x.label;
            });
            setListRef_id_cong_viec(res.data);
        });
    }
    const close = async () => {
        if(props.fnClose) props.fnClose();
        else navigate(linkList);
        //navigate(-1);
    }
    return (
        <div >
            <Dialog visible={showMessage} onHide={() => setShowMessage(false)} position="top" footer={dialogFooter} showHeader={false} breakpoints={{ '960px': '80vw' }} style={{ width: '30vw' }}>
                <div className="flex justify-content-center flex-column pt-6 px-3">
                    
                </div>
            </Dialog>

            <Card title={(itemId === 'new' ? 'Thêm' : 'Sửa') + ' Timesheet'}>
                <form className="p-fluid" onSubmit={handleSubmit(onSubmit)}>
                    <div className='row'>
                        <Controller name="xxx" control={control} render={({ field, fieldState }) => (
                            <InputText {...field} className={'hide'} value={field.value} />
                        )} />

                        <div className="col-sm-12">
                            <label htmlFor="id_cong_viec">
                                {'Công việc'} 
                            </label>
                            <Controller name="id_cong_viec" control={control} rules={{ 
                                //validate: value => value === 'pwd' || "The passwords do not match",
                                //pattern: {
                                //  value: /^[a-zA-Z]+$/,
                                //  message: 'pattern'
                                //},
                            }} render={({ field, fieldState }) => (
                                <Dropdown options={listRef_id_cong_viec} optionValue='Value' optionLabel='Text' scrollHeight={'600px'} className=''
                                    {...field}
                                    value={field.value??''}
                                    placeholder='--Chọn--'
                                    showClear
                                />
                            )} />
                            {getFormErrorMessage('id_cong_viec', errors)}
                        </div>
                        <div className="col-sm-6">
                            <label htmlFor="ngay_lam_viec">
                                {'Ngày làm'} 
                            </label>
                            <Controller name="ngay_lam_viec" control={control} rules={{ 
                                //validate: value => value === 'pwd' || "The passwords do not match",
                                //pattern: {
                                //  value: /^[a-zA-Z]+$/,
                                //  message: 'pattern'
                                //},
                            }} render={({ field, fieldState }) => (
                                    <Calendar
                                        className=''
                                        showButtonBar={true}
                                        dateFormat="dd/mm/yy"
                                        id="ngay_lam_viec"
                                        {...field} value={field.value??''} 
                                        mask="99/99/9999"
                                        showIcon
                                        placeholder='Ngày làm'
                                />
                            )} />
                            {getFormErrorMessage('ngay_lam_viec', errors)}
                        </div>
                        <div className="col-sm-6">
                            <label htmlFor="so_gio">
                                {'Số giờ'} 
                            </label>
                            <Controller name="so_gio" control={control} rules={{ 
                                //validate: value => value === 'pwd' || "The passwords do not match",
                                //pattern: {
                                //  value: /^[a-zA-Z]+$/,
                                //  message: 'pattern'
                                //},
                            }} render={({ field, fieldState }) => (
                                <InputText type='number' {...field} value={field.value??''} />
                            )} />
                            {getFormErrorMessage('so_gio', errors)}
                        </div>
                        <div className={props.fnClose ? 'text-center' : 'col-12'}>
                            <Button label={labelSave} icon='fa fa-save' style={{ width: '100px' }} />
                            <Link to={null} onClick={close.bind(this)}>
                                <Button className="btnClose"style={{ width: 100 }} label={labelClose} />
                            </Link>
                        </div>
                    </div>
                </form>

            </Card>
        </div>
    )
}
export default GC_LICH_HANG_NGAYForm;
