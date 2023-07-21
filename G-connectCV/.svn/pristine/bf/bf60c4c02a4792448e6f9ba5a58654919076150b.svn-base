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

import { qtht_nhat_ky_he_thongService } from 'modules/qtht_nhat_ky_he_thong/qtht_nhat_ky_he_thongService';

const qtht_nhat_ky_he_thongForm = (props) => {
    const { t, i18n } = useTranslation();
    let { id } = useParams();
    let itemId = props.id ?? id;
    const linkList = '/admin/qtht_nhat_ky_he_thong';
    const labelSave = 'Lưu';
    const labelClose = 'Đóng';
    const itemService = qtht_nhat_ky_he_thongService;
    const dialogFooter = <div className="flex justify-content-center"><Button label="OK" className="p-button-text" autoFocus onClick={() => setShowMessage(false)} /></div>;
    /* */
    let navigate = useNavigate();
    const defaultValues = {
    }
    const [formData, setFormData] = useState({});
    const [showMessage, setShowMessage] = useState(false);

    const [listRef_nguoi_thuc_hien_id, setListRef_nguoi_thuc_hien_id] = useState([]);
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

        getListRef_nguoi_thuc_hien_id();
    },[window.location.href]);

    const getListRef_nguoi_thuc_hien_id = () => {
        return qtht_nhat_ky_he_thongService.getAllRef_nguoi_thuc_hien_id().then(res => {
            res.data.map(x => {
                x.Value = x.value;
                x.Text = x.label;
            });
            setListRef_nguoi_thuc_hien_id(res.data);
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

            <Card title={(itemId === 'new' ? 'Thêm' : 'Sửa') + ' Title of qtht_nhat_ky_he_thong'}>
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
                                <label htmlFor="bang">
                                    {'Title of bang'} 
                                </label>
                                <Controller name="bang" control={control} rules={{ 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                    <CkEditor editor='content' id='content' 
                                        config={{ height: 300}}
                                        content={field.value} 
                                        events={{
                                            'change':(event)=>{
                                                field.onChange(event.editor.getData());
                                            }
                                        }}
                                    className={classNames({ 'p-invalid': fieldState.invalid })} />
                                )} />
                                {getFormErrorMessage('bang', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="ban_ghi_id">
                                    {'Title of ban_ghi_id'} 
                                </label>
                                <Controller name="ban_ghi_id" control={control} rules={{ 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                    <InputText {...field} value={field.value??''} />
                                )} />
                                {getFormErrorMessage('ban_ghi_id', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="nguoi_thuc_hien_id">
                                    {'Title of nguoi_thuc_hien_id'} 
                                </label>
                                <Controller name="nguoi_thuc_hien_id" control={control} rules={{ 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                    <Dropdown options={listRef_nguoi_thuc_hien_id} optionValue='Value' optionLabel='Text' scrollHeight={'600px'} className=''
                                        {...field}
                                        value={field.value??''}
                                        placeholder='--Chọn--'
                                        showClear
                                    />
                                )} />
                                {getFormErrorMessage('nguoi_thuc_hien_id', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="hanh_dong">
                                    {'Title of hanh_dong'} 
                                </label>
                                <Controller name="hanh_dong" control={control} rules={{ 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                    <CkEditor editor='content' id='content' 
                                        config={{ height: 300}}
                                        content={field.value} 
                                        events={{
                                            'change':(event)=>{
                                                field.onChange(event.editor.getData());
                                            }
                                        }}
                                    className={classNames({ 'p-invalid': fieldState.invalid })} />
                                )} />
                                {getFormErrorMessage('hanh_dong', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="noi_dung">
                                    {'Title of noi_dung'} 
                                </label>
                                <Controller name="noi_dung" control={control} rules={{ 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                    <CkEditor editor='content' id='content' 
                                        config={{ height: 300}}
                                        content={field.value} 
                                        events={{
                                            'change':(event)=>{
                                                field.onChange(event.editor.getData());
                                            }
                                        }}
                                    className={classNames({ 'p-invalid': fieldState.invalid })} />
                                )} />
                                {getFormErrorMessage('noi_dung', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="duong_dan">
                                    {'Title of duong_dan'} 
                                </label>
                                <Controller name="duong_dan" control={control} rules={{ 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                    <CkEditor editor='content' id='content' 
                                        config={{ height: 300}}
                                        content={field.value} 
                                        events={{
                                            'change':(event)=>{
                                                field.onChange(event.editor.getData());
                                            }
                                        }}
                                    className={classNames({ 'p-invalid': fieldState.invalid })} />
                                )} />
                                {getFormErrorMessage('duong_dan', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="is_deleted">
                                    {'Title of is_deleted'} 
                                </label>
                                <Controller name="is_deleted" control={control} rules={{ 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                      <InputSwitch trueValue={ACTIVE} falseValue={DEACTIVE}  tooltip={field.value ==ACTIVE ? statusText.active : statusText.deactive }  checked={field.value} onChange={(e) => field.onChange(e.target.value)} />
                                )} />
                                {getFormErrorMessage('is_deleted', errors)}
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
export default qtht_nhat_ky_he_thongForm;
