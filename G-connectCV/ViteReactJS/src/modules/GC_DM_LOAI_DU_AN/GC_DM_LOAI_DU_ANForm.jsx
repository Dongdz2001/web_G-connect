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

import getFormErrorMessage from 'shared/components/getFormErrorMessage';
import sessionStorage from 'redux-persist/es/storage/session';

import { GC_DM_LOAI_DU_ANService } from 'modules/GC_DM_LOAI_DU_AN/GC_DM_LOAI_DU_ANService';

const GC_DM_LOAI_DU_ANForm = (props) => {
    const { t, i18n } = useTranslation();
    let { id } = useParams();
    let itemId = props.id ?? id;
    const linkList = '/admin/GC_DM_LOAI_DU_AN';
    const labelSave = 'Lưu';
    const labelClose = 'Đóng';
    const itemService = GC_DM_LOAI_DU_ANService;
    const dialogFooter = <div className="flex justify-content-center"><Button label="OK" className="p-button-text" autoFocus onClick={() => setShowMessage(false)} /></div>;
    /* */
    let navigate = useNavigate();
    const defaultValues = {
    }
    const [formData, setFormData] = useState({});
    const [showMessage, setShowMessage] = useState(false);

    const { register, control, formState: { errors }, handleSubmit, reset, watch, getValues, setValue } = useForm({ defaultValues });
    const getFormErrorMessage = (name) => {
        return errors[name] && <small className="p-error">{errors[name].message}</small>
    };
    const onSubmit = async (formData) => {
        if(itemId === 'new'){
            //console.log(formData);
            await itemService.create(formData);
        } else {
            await itemService.update(itemId, formData);
        }
        if(props.fnLoadData) props.fnLoadData();
        if(props.fnClose) props.fnClose();
        else navigate(linkList);
    }
    const getById = async (itemId)=>{
        let result = await itemService.getById(itemId);
        reset(result.data);
    }
    useEffect(() => {
        if(itemId !=='new') getById(itemId);

    },[window.location.href]);

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

            <Card title={(itemId === 'new' ? 'Thêm' : 'Sửa') + ' Danh mục Loại dự án'}>
                <form className="p-fluid" onSubmit={handleSubmit(onSubmit)}>
                    <div className='row'>
                        <div className={props.fnClose ? 'text-center' : 'col-12'}>
                            <Button label={labelSave} icon='fa fa-save' style={{ width: '100px' }} />
                            <Button className="btnClose" style={{width:100}} onClick={close.bind(this)} label={labelClose}></Button>
                        </div>
                        <br/><br/>

                        <Controller name="xxx" control={control} render={({ field, fieldState }) => (
                            <InputText {...field} className={'hide'} value={field.value} />
                        )} />

                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="ten_loai_du_an">
                                    {'Tên loại dự án'} <span className='p-error'>(*)</span>
                                </label>
                                <Controller name="ten_loai_du_an" control={control} rules={{ 
                                    required: {
                                        value: true,
                                        message: 'Vui lòng nhập!'
                                    }, 
                                    maxLength: {
                                        value: 200,
                                        message: 'Không quá 200 ký tự'
                                    }, 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                    <InputText {...field} value={field.value??''} />
                                )} />
                                {getFormErrorMessage('ten_loai_du_an', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="stt">
                                    {'Thứ tự'} 
                                </label>
                                <Controller name="stt" control={control} rules={{ 
                                    maxLength: {
                                        value: 11,
                                        message: 'Không quá 11 ký tự'
                                    }, 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                    <InputText {...field} value={field.value??''} />
                                )} />
                                {getFormErrorMessage('stt', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="nguoi_tao_id">
                                    {'Title of nguoi_tao_id'} 
                                </label>
                                <Controller name="nguoi_tao_id" control={control} rules={{ 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                    <InputText {...field} value={field.value??''} />
                                )} />
                                {getFormErrorMessage('nguoi_tao_id', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-2">
                                <label htmlFor="ngay_tao">
                                    {'Title of ngay_tao'} 
                                </label>
                                <Controller name="ngay_tao" control={control} rules={{ 
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
                                          id="ngay_tao"
                                          {...field} value={field.value??''} 
                                          mask="99/99/9999"
                                          showIcon
                                          placeholder='Title of ngay_tao'
                                    />
                                )} />
                                {getFormErrorMessage('ngay_tao', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="nguoi_chinh_sua_id">
                                    {'Title of nguoi_chinh_sua_id'} 
                                </label>
                                <Controller name="nguoi_chinh_sua_id" control={control} rules={{ 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                    <InputText {...field} value={field.value??''} />
                                )} />
                                {getFormErrorMessage('nguoi_chinh_sua_id', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-2">
                                <label htmlFor="ngay_chinh_sua">
                                    {'Title of ngay_chinh_sua'} 
                                </label>
                                <Controller name="ngay_chinh_sua" control={control} rules={{ 
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
                                          id="ngay_chinh_sua"
                                          {...field} value={field.value??''} 
                                          mask="99/99/9999"
                                          showIcon
                                          placeholder='Title of ngay_chinh_sua'
                                    />
                                )} />
                                {getFormErrorMessage('ngay_chinh_sua', errors)}
                            </div>
                        </div>

                        <div className={props.fnClose ? 'text-center' : 'col-12'}>
                            <Button label={labelSave} icon='fa fa-save' style={{ width: '100px' }} />
                            <Button className="btnClose" style={{width:100}} onClick={close.bind(this)} label={labelClose}></Button>
                        </div>
                    </div>
                </form>

            </Card>
        </div>
    )
}
export default GC_DM_LOAI_DU_ANForm;
