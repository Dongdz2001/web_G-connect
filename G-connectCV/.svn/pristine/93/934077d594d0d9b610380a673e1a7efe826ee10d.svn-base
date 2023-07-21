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

import { GC_VAN_DE_CAN_GIAI_QUYETService } from 'modules/GC_VAN_DE_CAN_GIAI_QUYET/GC_VAN_DE_CAN_GIAI_QUYETService';

const GC_VAN_DE_CAN_GIAI_QUYETForm = (props) => {
    const { t, i18n } = useTranslation();
    let { id } = useParams();
    let itemId = props.id ?? id;
    const linkList = '/admin/GC_VAN_DE_CAN_GIAI_QUYET';
    const labelSave = 'Lưu';
    const labelClose = 'Đóng';
    const itemService = GC_VAN_DE_CAN_GIAI_QUYETService;
    const dialogFooter = <div className="flex justify-content-center"><Button label="OK" className="p-button-text" autoFocus onClick={() => setShowMessage(false)} /></div>;
    /* */
    let navigate = useNavigate();
    const defaultValues = {
    }
    const [formData, setFormData] = useState({});
    const [showMessage, setShowMessage] = useState(false);

    const [listRef_id_chuc_nang, setListRef_id_chuc_nang] = useState([]);
    const [listRef_id_cong_viec, setListRef_id_cong_viec] = useState([]);
    const [listRef_id_nguoi_gap, setListRef_id_nguoi_gap] = useState([]);
    const [listRef_id_nguoi_phoi_hop, setListRef_id_nguoi_phoi_hop] = useState([]);
    const [listRef_id_nguoi_giai_quyet, setListRef_id_nguoi_giai_quyet] = useState([]);
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

        getListRef_id_chuc_nang();
        getListRef_id_cong_viec();
        getListRef_id_nguoi_gap();
        getListRef_id_nguoi_phoi_hop();
        getListRef_id_nguoi_giai_quyet();
    },[window.location.href]);

    const getListRef_id_chuc_nang = () => {
        return GC_VAN_DE_CAN_GIAI_QUYETService.getAllRef_id_chuc_nang().then(res => {
            res.data.map(x => {
                x.Value = x.value;
                x.Text = x.label;
            });
            setListRef_id_chuc_nang(res.data);
        });
    }
    const getListRef_id_cong_viec = () => {
        return GC_VAN_DE_CAN_GIAI_QUYETService.getAllRef_id_cong_viec().then(res => {
            res.data.map(x => {
                x.Value = x.value;
                x.Text = x.label;
            });
            setListRef_id_cong_viec(res.data);
        });
    }
    const getListRef_id_nguoi_gap = () => {
        return GC_VAN_DE_CAN_GIAI_QUYETService.getAllRef_id_nguoi_gap().then(res => {
            res.data.map(x => {
                x.Value = x.value;
                x.Text = x.label;
            });
            setListRef_id_nguoi_gap(res.data);
        });
    }
    const getListRef_id_nguoi_phoi_hop = () => {
        return GC_VAN_DE_CAN_GIAI_QUYETService.getAllRef_id_nguoi_phoi_hop().then(res => {
            res.data.map(x => {
                x.Value = x.value;
                x.Text = x.label;
            });
            setListRef_id_nguoi_phoi_hop(res.data);
        });
    }
    const getListRef_id_nguoi_giai_quyet = () => {
        return GC_VAN_DE_CAN_GIAI_QUYETService.getAllRef_id_nguoi_giai_quyet().then(res => {
            res.data.map(x => {
                x.Value = x.value;
                x.Text = x.label;
            });
            setListRef_id_nguoi_giai_quyet(res.data);
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

            <Card title={(itemId === 'new' ? 'Thêm' : 'Sửa') + ' Vấn đề cần giải quyết'}>
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
                                <label htmlFor="id_chuc_nang">
                                    {'Chức năng'} 
                                </label>
                                <Controller name="id_chuc_nang" control={control} rules={{ 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                    <Dropdown options={listRef_id_chuc_nang} optionValue='Value' optionLabel='Text' scrollHeight={'600px'} className=''
                                        {...field}
                                        value={field.value??''}
                                        placeholder='--Chọn--'
                                        showClear
                                    />
                                )} />
                                {getFormErrorMessage('id_chuc_nang', errors)}
                            </div>
                        </div>
                        <div className="col-12">
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
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="id_nguoi_gap">
                                    {'Người gặp'} 
                                </label>
                                <Controller name="id_nguoi_gap" control={control} rules={{ 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                    <Dropdown options={listRef_id_nguoi_gap} optionValue='Value' optionLabel='Text' scrollHeight={'600px'} className=''
                                        {...field}
                                        value={field.value??''}
                                        placeholder='--Chọn--'
                                        showClear
                                    />
                                )} />
                                {getFormErrorMessage('id_nguoi_gap', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="id_nguoi_phoi_hop">
                                    {'Người phối hợp'} 
                                </label>
                                <Controller name="id_nguoi_phoi_hop" control={control} rules={{ 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                    <Dropdown options={listRef_id_nguoi_phoi_hop} optionValue='Value' optionLabel='Text' scrollHeight={'600px'} className=''
                                        {...field}
                                        value={field.value??''}
                                        placeholder='--Chọn--'
                                        showClear
                                    />
                                )} />
                                {getFormErrorMessage('id_nguoi_phoi_hop', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="id_nguoi_giai_quyet">
                                    {'Người giải quyết'} 
                                </label>
                                <Controller name="id_nguoi_giai_quyet" control={control} rules={{ 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                    <Dropdown options={listRef_id_nguoi_giai_quyet} optionValue='Value' optionLabel='Text' scrollHeight={'600px'} className=''
                                        {...field}
                                        value={field.value??''}
                                        placeholder='--Chọn--'
                                        showClear
                                    />
                                )} />
                                {getFormErrorMessage('id_nguoi_giai_quyet', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="ten_van_de">
                                    {'Tên vấn đề'} <span className='p-error'>(*)</span>
                                </label>
                                <Controller name="ten_van_de" control={control} rules={{ 
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
                                {getFormErrorMessage('ten_van_de', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="noi_dung">
                                    {'Mô tả'} 
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
                                <label htmlFor="huong_giai_quyet">
                                    {'Hướng giải quyết'} 
                                </label>
                                <Controller name="huong_giai_quyet" control={control} rules={{ 
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
                                {getFormErrorMessage('huong_giai_quyet', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="da_giai_quyet">
                                    {'Đã xong'} 
                                </label>
                                <Controller name="da_giai_quyet" control={control} rules={{ 
                                    //validate: value => value === 'pwd' || "The passwords do not match",
                                    //pattern: {
                                    //  value: /^[a-zA-Z]+$/,
                                    //  message: 'pattern'
                                    //},
                                }} render={({ field, fieldState }) => (
                                      <InputSwitch trueValue={ACTIVE} falseValue={DEACTIVE}  tooltip={field.value ==ACTIVE ? statusText.active : statusText.deactive }  checked={field.value} onChange={(e) => field.onChange(e.target.value)} />
                                )} />
                                {getFormErrorMessage('da_giai_quyet', errors)}
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
export default GC_VAN_DE_CAN_GIAI_QUYETForm;
