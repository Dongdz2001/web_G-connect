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

import { qtht_file_dinh_kemService } from 'modules/qtht_file_dinh_kem/qtht_file_dinh_kemService';

const qtht_file_dinh_kemFormView = (props) => {
    const { t, i18n } = useTranslation();
    let { id } = useParams();
    let itemId = props.id ?? id;
    const linkList = '/admin/qtht_file_dinh_kem';
    const labelSave = 'Lưu';
    const labelClose = 'Đóng';
    const itemService = qtht_file_dinh_kemService;
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

            <Card title={'Xem Title of qtht_file_dinh_kem'}>
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
                                <label htmlFor="duong_dan">
                                    {'Title of duong_dan'}
                                </label>
                            </div>
                            <div className="col-sm-10">
                                <Controller name="duong_dan" control={control} render={({ field, fieldState }) => (
                                    <label className="p-inputtext">{field.value??''}</label>
                                )} />
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-2">
                                <label htmlFor="type">
                                    {'Title of type'}
                                </label>
                            </div>
                            <div className="col-sm-10">
                                <Controller name="type" control={control} render={({ field, fieldState }) => (
                                    <label className="p-inputtext">{field.value??''}</label>
                                )} />
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-2">
                                <label htmlFor="noi_dung_tep">
                                    {'Title of noi_dung_tep'}
                                </label>
                            </div>
                            <div className="col-sm-10">
                                <Controller name="noi_dung_tep" control={control} render={({ field, fieldState }) => (
                                    <label className="p-inputtext">{field.value??''}</label>
                                )} />
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-2">
                                <label htmlFor="noi_dung_tep_pdf">
                                    {'Title of noi_dung_tep_pdf'}
                                </label>
                            </div>
                            <div className="col-sm-10">
                                <Controller name="noi_dung_tep_pdf" control={control} render={({ field, fieldState }) => (
                                    <label className="p-inputtext">{field.value??''}</label>
                                )} />
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-2">
                                <label htmlFor="file_finish">
                                    {'Title of file_finish'}
                                </label>
                            </div>
                            <div className="col-sm-10">
                                <Controller name="file_finish" control={control} render={({ field, fieldState }) => (
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
export default qtht_file_dinh_kemFormView;
