﻿import React, { useEffect, useState, useRef } from 'react';
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

import { qtht_nguoi_dungService } from 'modules/qtht_nguoi_dung/qtht_nguoi_dungService';

const qtht_nguoi_dungFormView = (props) => {
    const { t, i18n } = useTranslation();
    let { id } = useParams();
    let itemId = props.id ?? id;
    const linkList = '/admin/qtht_nguoi_dung';
    const labelSave = 'Lưu';
    const labelClose = 'Đóng';
    const itemService = qtht_nguoi_dungService;
    const dialogFooter = <div className="flex justify-content-center"><Button label="OK" className="p-button-text" autoFocus onClick={() => setShowMessage(false)} /></div>;
    /* */
    let navigate = useNavigate();
    const defaultValues = {
    }
    const [formData, setFormData] = useState({});
    const [showMessage, setShowMessage] = useState(false);
//{J}
    const { register, control, formState: { errors }, handleSubmit, reset, watch, getValues, setValue } = useForm({ defaultValues });
    const getFormErrorMessage = (name) => {
        return errors[name] && <small className="p-error">{errors[name].message}</small>
    };
    const getById = async (itemId)=>{
        let result = await itemService.getById(itemId);
        reset(result.data);
    }
    useEffect(() => {
        if(itemId !=='new') getById(itemId);
//{M}
    },[window.location.href]);
//{K}
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

            <Card title={'Xem Title of qtht_nguoi_dung'}>
                <div className="view-form">
                    <div className='row'>
                        <div className={props.fnClose ? 'text-center' : 'col-12'}>
                            <Button className="btnClose" style={{width:100}} onClick={close.bind(this)} label={labelClose}></Button>
                        </div>

                        <Controller name="xxx" control={control} render={({ field, fieldState }) => (
                            <InputText {...field} className={'hide'} value={field.value} />
                        )} />

                        <div className="col-12">
                            <div className="col-sm-2">
                                <label htmlFor="tai_khoan">
                                    {'Tài khoản'}
                                </label>
                            </div>
                            <div className="col-sm-10">
                                <Controller name="tai_khoan" control={control} render={({ field, fieldState }) => (
                                    <label className="p-inputtext">{field.value??''}</label>
                                )} />
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-2">
                                <label htmlFor="mat_khau">
                                    {'Title of mat_khau'}
                                </label>
                            </div>
                            <div className="col-sm-10">
                                <Controller name="mat_khau" control={control} render={({ field, fieldState }) => (
                                    <label className="p-inputtext">{field.value??''}</label>
                                )} />
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-2">
                                <label htmlFor="salt_code">
                                    {'Title of salt_code'}
                                </label>
                            </div>
                            <div className="col-sm-10">
                                <Controller name="salt_code" control={control} render={({ field, fieldState }) => (
                                    <label className="p-inputtext">{field.value??''}</label>
                                )} />
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-2">
                                <label htmlFor="ten">
                                    {'Title of ten'}
                                </label>
                            </div>
                            <div className="col-sm-10">
                                <Controller name="ten" control={control} render={({ field, fieldState }) => (
                                    <label className="p-inputtext">{field.value??''}</label>
                                )} />
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-2">
                                <label htmlFor="trang_thai">
                                    {'Title of trang_thai'}
                                </label>
                            </div>
                            <div className="col-sm-10">
                                <Controller name="trang_thai" control={control} render={({ field, fieldState }) => (
                                    <label className="p-inputtext">{field.value??''}</label>
                                )} />
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-2">
                                <label htmlFor="super_admin">
                                    {'Title of super_admin'}
                                </label>
                            </div>
                            <div className="col-sm-10">
                                <Controller name="super_admin" control={control} render={({ field, fieldState }) => (
                                    <label className="p-inputtext">{field.value??''}</label>
                                )} />
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-2">
                                <label htmlFor="email">
                                    {'Title of email'}
                                </label>
                            </div>
                            <div className="col-sm-10">
                                <Controller name="email" control={control} render={({ field, fieldState }) => (
                                    <label className="p-inputtext">{field.value??''}</label>
                                )} />
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-2">
                                <label htmlFor="so_dien_thoai">
                                    {'Title of so_dien_thoai'}
                                </label>
                            </div>
                            <div className="col-sm-10">
                                <Controller name="so_dien_thoai" control={control} render={({ field, fieldState }) => (
                                    <label className="p-inputtext">{field.value??''}</label>
                                )} />
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-2">
                                <label htmlFor="anh_dai_dien_url">
                                    {'Title of anh_dai_dien_url'}
                                </label>
                            </div>
                            <div className="col-sm-10">
                                <Controller name="anh_dai_dien_url" control={control} render={({ field, fieldState }) => (
                                    <label className="p-inputtext">{field.value??''}</label>
                                )} />
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-2">
                                <label htmlFor="is_dau_moi">
                                    {'Title of is_dau_moi'}
                                </label>
                            </div>
                            <div className="col-sm-10">
                                <Controller name="is_dau_moi" control={control} render={({ field, fieldState }) => (
                                    <label className="p-inputtext">{field.value??''}</label>
                                )} />
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-2">
                                <label htmlFor="ten_chuc_vu_id">
                                    {'Title of chuc_vu_id'}
                                </label>
                            </div>
                            <div className="col-sm-10">
                                <Controller name="ten_chuc_vu_id" control={control} render={({ field, fieldState }) => (
                                    <label className="p-inputtext">{field.value??''}</label>
                                )} />
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-2">
                                <label htmlFor="ten_file_dinh_kem_id">
                                    {'Title of file_dinh_kem_id'}
                                </label>
                            </div>
                            <div className="col-sm-10">
                                <Controller name="ten_file_dinh_kem_id" control={control} render={({ field, fieldState }) => (
                                    <label className="p-inputtext">{field.value??''}</label>
                                )} />
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-2">
                                <label htmlFor="nguoi_tao_id">
                                    {'Title of nguoi_tao_id'}
                                </label>
                            </div>
                            <div className="col-sm-10">
                                <Controller name="nguoi_tao_id" control={control} render={({ field, fieldState }) => (
                                    <label className="p-inputtext">{field.value??''}</label>
                                )} />
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-2">
                                <label htmlFor="ngay_tao">
                                    {'Title of ngay_tao'}
                                </label>
                            </div>
                            <div className="col-sm-10">
                                <Controller name="ngay_tao" control={control} render={({ field, fieldState }) => (
                                    <label className="p-inputtext">{field.value??''}</label>
                                )} />
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-2">
                                <label htmlFor="nguoi_chinh_sua_id">
                                    {'Title of nguoi_chinh_sua_id'}
                                </label>
                            </div>
                            <div className="col-sm-10">
                                <Controller name="nguoi_chinh_sua_id" control={control} render={({ field, fieldState }) => (
                                    <label className="p-inputtext">{field.value??''}</label>
                                )} />
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-2">
                                <label htmlFor="ngay_chinh_sua">
                                    {'Title of ngay_chinh_sua'}
                                </label>
                            </div>
                            <div className="col-sm-10">
                                <Controller name="ngay_chinh_sua" control={control} render={({ field, fieldState }) => (
                                    <label className="p-inputtext">{field.value??''}</label>
                                )} />
                            </div>
                        </div>

                        <div className={props.fnClose ? 'text-center' : 'col-12'}>
                            <Button className="btnClose" style={{width:100}} onClick={close.bind(this)} label={labelClose}></Button>
                        </div>
                    </div>
                </div>

            </Card>
        </div>
    )
}
export default qtht_nguoi_dungFormView;