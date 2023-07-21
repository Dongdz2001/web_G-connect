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

import { qtht_don_viService } from 'modules/qtht_don_vi/qtht_don_viService';

const qtht_don_viForm = () => {
    const { t, i18n } = useTranslation();
    let { location_id } = useParams();
    let itemId = location_id;
    const linkList = '/admin/qtht_don_vi-list';
    const labelSave = 'Lưu';
    const labelClose = 'Đóng';
    const itemService = qtht_don_viService;
    const dialogFooter = <div className="flex justify-content-center"><Button label="OK" className="p-button-text" autoFocus onClick={() => setShowMessage(false)} /></div>;
    /* */
    let navigate = useNavigate();
    const defaultValues = {
    }
    const [formData, setFormData] = useState({});
    const [showMessage, setShowMessage] = useState(false);

    const [listRef_nguoi_tao_id, setListRef_nguoi_tao_id] = useState([]);
    const [listRef_nguoi_chinh_sua_id, setListRef_nguoi_chinh_sua_id] = useState([]);
    const [listRef_don_vi_cap_tren_id, setListRef_don_vi_cap_tren_id] = useState([]);
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
        navigate(linkList);
    }
    const getById = async (itemId)=>{
        let result = await itemService.getById(itemId);
        reset(result.data);
    }
    useEffect(() => {
        if(itemId !=='new') getById(itemId);

        getListRef_nguoi_tao_id();
        getListRef_nguoi_chinh_sua_id();
        getListRef_don_vi_cap_tren_id();
    },[window.location.href]);

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
    const close = async () => {
        navigate(linkList);
        //navigate(-1);
    }
    return (
        <div >
            <Dialog visible={showMessage} onHide={() => setShowMessage(false)} position="top" footer={dialogFooter} showHeader={false} breakpoints={{ '960px': '80vw' }} style={{ width: '30vw' }}>
                <div className="flex justify-content-center flex-column pt-6 px-3">
                    
                </div>
            </Dialog>

            <Card title={(itemId === 'new' ? 'Thêm' : 'Sửa') + ' Title of qtht_don_vi'}>
                <form className="p-fluid container" onSubmit={handleSubmit(onSubmit)}>
                    <div className='row'>
                        <div className='col-12'>
                            <Button label={labelSave} icon='fa fa-save' style={{ width: '100px' }} />
                            <Button className="btnClose" style={{width:100}} onClick={close.bind(this)} label={labelClose}></Button>
                        </div>
                        <br/><br/>

                        <Controller name="xxx" control={control} render={({ field, fieldState }) => (
                            <InputText {...field} className={'hide'} value={field.value} />
                        )} />

                        <div className="col-12">
                            <div className="col-sm-6">
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
                                    <Dropdown options={listRef_nguoi_tao_id} optionValue='Value' optionLabel='Text' scrollHeight={'600px'} className=''
                                        {...field}
                                        value={field.value??''}
                                        placeholder='--Chọn--'
                                        showClear
                                    />
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
                            <div className="col-sm-6">
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
                                    <Dropdown options={listRef_nguoi_chinh_sua_id} optionValue='Value' optionLabel='Text' scrollHeight={'600px'} className=''
                                        {...field}
                                        value={field.value??''}
                                        placeholder='--Chọn--'
                                        showClear
                                    />
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
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="ten">
                                    {'Title of ten'} <span className='p-error'>(*)</span>
                                </label>
                                <Controller name="ten" control={control} rules={{ 
                                    required: {
                                        value: true,
                                        message: 'Vui lòng nhập!'
                                    }, 
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
                                {getFormErrorMessage('ten', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="dai_dien">
                                    {'Title of dai_dien'} <span className='p-error'>(*)</span>
                                </label>
                                <Controller name="dai_dien" control={control} rules={{ 
                                    required: {
                                        value: true,
                                        message: 'Vui lòng nhập!'
                                    }, 
                                    maxLength: {
                                        value: 5255,
                                        message: 'Không quá 5255 ký tự'
                                    }, 
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
                                {getFormErrorMessage('dai_dien', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-6">
                                <label htmlFor="dia_chi">
                                    {'Title of dia_chi'} 
                                </label>
                                <Controller name="dia_chi" control={control} rules={{ 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                      <InputSwitch trueValue={ACTIVE} falseValue={DEACTIVE}  tooltip={field.value ==ACTIVE ? statusText.active : statusText.deactive }  checked={field.value} onChange={(e) => field.onChange(e.target.value)} />
                                )} />
                                {getFormErrorMessage('dia_chi', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="truc_thuoc">
                                    {'Title of truc_thuoc'} 
                                </label>
                                <Controller name="truc_thuoc" control={control} rules={{ 
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
                                {getFormErrorMessage('truc_thuoc', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-6">
                                <label htmlFor="dien_thoai">
                                    {'Title of dien_thoai'} 
                                </label>
                                <Controller name="dien_thoai" control={control} rules={{ 
                                    maxLength: {
                                        value: 32,
                                        message: 'Không quá 32 ký tự'
                                    }, 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                    <InputText {...field} value={field.value??''} />
                                )} />
                                {getFormErrorMessage('dien_thoai', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="mo_ta">
                                    {'Title of mo_ta'} 
                                </label>
                                <Controller name="mo_ta" control={control} rules={{ 
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
                                {getFormErrorMessage('mo_ta', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-6">
                                <label htmlFor="don_vi_cap_tren_id">
                                    {'Title of don_vi_cap_tren_id'} 
                                </label>
                                <Controller name="don_vi_cap_tren_id" control={control} rules={{ 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                    <Dropdown options={listRef_don_vi_cap_tren_id} optionValue='Value' optionLabel='Text' scrollHeight={'600px'} className=''
                                        {...field}
                                        value={field.value??''}
                                        placeholder='--Chọn--'
                                        showClear
                                    />
                                )} />
                                {getFormErrorMessage('don_vi_cap_tren_id', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-2">
                                <label htmlFor="cap_don_vi">
                                    {'Title of cap_don_vi'} <span className='p-error'>(*)</span>
                                </label>
                                <Controller name="cap_don_vi" control={control} rules={{ 
                                    required: {
                                        value: true,
                                        message: 'Vui lòng nhập!'
                                    }, 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                         <SelectImgItem label='' {...field} value={field.value} onSelectImage={(e) => {
                                                   field.onChange(e);
                                         }} />
                                )} />
                                {getFormErrorMessage('cap_don_vi', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="muc_luc">
                                    {'Title of muc_luc'} 
                                </label>
                                <Controller name="muc_luc" control={control} rules={{ 
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
                                {getFormErrorMessage('muc_luc', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-6">
                                <label htmlFor="ma">
                                    {'Title of ma'} <span className='p-error'>(*)</span>
                                </label>
                                <Controller name="ma" control={control} rules={{ 
                                    required: {
                                        value: true,
                                        message: 'Vui lòng nhập!'
                                    }, 
                                    maxLength: {
                                        value: 32,
                                        message: 'Không quá 32 ký tự'
                                    }, 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                    <InputText {...field} value={field.value??''} />
                                )} />
                                {getFormErrorMessage('ma', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="ten_day_du">
                                    {'Title of ten_day_du'} 
                                </label>
                                <Controller name="ten_day_du" control={control} rules={{ 
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
                                {getFormErrorMessage('ten_day_du', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-6">
                                <label htmlFor="loai">
                                    {'Title of loai'} <span className='p-error'>(*)</span>
                                </label>
                                <Controller name="loai" control={control} rules={{ 
                                    required: {
                                        value: true,
                                        message: 'Vui lòng nhập!'
                                    }, 
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
                                {getFormErrorMessage('loai', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="dia_chi_kbnn">
                                    {'Title of dia_chi_kbnn'} 
                                </label>
                                <Controller name="dia_chi_kbnn" control={control} rules={{ 
                                    maxLength: {
                                        value: 255,
                                        message: 'Không quá 255 ký tự'
                                    }, 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                    <InputTextarea rows="3" {...field} value={field.value??''} />
                                )} />
                                {getFormErrorMessage('dia_chi_kbnn', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="tai_khoan">
                                    {'Title of tai_khoan'} 
                                </label>
                                <Controller name="tai_khoan" control={control} rules={{ 
                                    maxLength: {
                                        value: 255,
                                        message: 'Không quá 255 ký tự'
                                    }, 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                    <InputTextarea rows="3" {...field} value={field.value??''} />
                                )} />
                                {getFormErrorMessage('tai_khoan', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="ma_order">
                                    {'Title of ma_order'} 
                                </label>
                                <Controller name="ma_order" control={control} rules={{ 
                                    maxLength: {
                                        value: 255,
                                        message: 'Không quá 255 ký tự'
                                    }, 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                    <InputTextarea rows="3" {...field} value={field.value??''} />
                                )} />
                                {getFormErrorMessage('ma_order', errors)}
                            </div>
                        </div>

                        <div className='col-12'>
                            <Button label={labelSave} icon='fa fa-save' style={{ width: '100px' }} />
                            <Button className="btnClose" style={{width:100}} onClick={close.bind(this)} label={labelClose}></Button>
                        </div>
                    </div>
                </form>

            </Card>
        </div>
    )
}
export default qtht_don_viForm;
