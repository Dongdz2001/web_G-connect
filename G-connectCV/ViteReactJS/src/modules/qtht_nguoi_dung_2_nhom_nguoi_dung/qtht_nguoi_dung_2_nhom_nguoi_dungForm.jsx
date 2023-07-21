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

import { qtht_nguoi_dung_2_nhom_nguoi_dungService } from 'modules/qtht_nguoi_dung_2_nhom_nguoi_dung/qtht_nguoi_dung_2_nhom_nguoi_dungService';

const qtht_nguoi_dung_2_nhom_nguoi_dungForm = (props) => {
    const { t, i18n } = useTranslation();
    let { id } = useParams();
    let itemId = props.id ?? id;
    const linkList = '/admin/qtht_nguoi_dung_2_nhom_nguoi_dung';
    const labelSave = 'Lưu';
    const labelClose = 'Đóng';
    const itemService = qtht_nguoi_dung_2_nhom_nguoi_dungService;
    const dialogFooter = <div className="flex justify-content-center"><Button label="OK" className="p-button-text" autoFocus onClick={() => setShowMessage(false)} /></div>;
    /* */
    let navigate = useNavigate();
    const defaultValues = {
    }
    const [formData, setFormData] = useState({});
    const [showMessage, setShowMessage] = useState(false);

    const [listRef_nguoi_dung_id, setListRef_nguoi_dung_id] = useState([]);
    const [listRef_nhom_nguoi_dung_id, setListRef_nhom_nguoi_dung_id] = useState([]);
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

        getListRef_nguoi_dung_id();
        getListRef_nhom_nguoi_dung_id();
    },[window.location.href]);

    const getListRef_nguoi_dung_id = () => {
        return qtht_nguoi_dung_2_nhom_nguoi_dungService.getAllRef_nguoi_dung_id().then(res => {
            res.data.map(x => {
                x.Value = x.value;
                x.Text = x.label;
            });
            setListRef_nguoi_dung_id(res.data);
        });
    }
    const getListRef_nhom_nguoi_dung_id = () => {
        return qtht_nguoi_dung_2_nhom_nguoi_dungService.getAllRef_nhom_nguoi_dung_id().then(res => {
            res.data.map(x => {
                x.Value = x.value;
                x.Text = x.label;
            });
            setListRef_nhom_nguoi_dung_id(res.data);
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

            <Card title={(itemId === 'new' ? 'Thêm' : 'Sửa') + ' Title of qtht_nguoi_dung_2_nhom_nguoi_dung'}>
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
                                <label htmlFor="nguoi_dung_id">
                                    {'Title of nguoi_dung_id'} <span className='p-error'>(*)</span>
                                </label>
                                <Controller name="nguoi_dung_id" control={control} rules={{ 
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
                                    <Dropdown options={listRef_nguoi_dung_id} optionValue='Value' optionLabel='Text' scrollHeight={'600px'} className=''
                                        {...field}
                                        value={field.value??''}
                                        placeholder='--Chọn--'
                                        showClear
                                    />
                                )} />
                                {getFormErrorMessage('nguoi_dung_id', errors)}
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="col-sm-12">
                                <label htmlFor="nhom_nguoi_dung_id">
                                    {'Title of nhom_nguoi_dung_id'} <span className='p-error'>(*)</span>
                                </label>
                                <Controller name="nhom_nguoi_dung_id" control={control} rules={{ 
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
                                    <Dropdown options={listRef_nhom_nguoi_dung_id} optionValue='Value' optionLabel='Text' scrollHeight={'600px'} className=''
                                        {...field}
                                        value={field.value??''}
                                        placeholder='--Chọn--'
                                        showClear
                                    />
                                )} />
                                {getFormErrorMessage('nhom_nguoi_dung_id', errors)}
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
export default qtht_nguoi_dung_2_nhom_nguoi_dungForm;
