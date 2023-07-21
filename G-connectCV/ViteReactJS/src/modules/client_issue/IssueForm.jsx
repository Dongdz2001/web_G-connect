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
import { getCurrentUserDefault } from 'shared/utils/getCurrentUserDefault';
import { Link } from "react-router-dom";
import { GC_CHUC_NANGService } from "modules/GC_CHUC_NANG/GC_CHUC_NANGService";

import { useNavigate } from "react-router-dom";
import { useTranslation } from 'react-i18next'

import { GC_VAN_DE_CAN_GIAI_QUYETService } from 'modules/GC_VAN_DE_CAN_GIAI_QUYET/GC_VAN_DE_CAN_GIAI_QUYETService';
import { Toast } from 'primereact/toast';
import CKEditor from 'components/ckeditor4/CkEditor';

const IssueForm = (props) => {
    const { t, i18n } = useTranslation();
    let { id } = useParams();
    let itemId = props.id ?? id;

    const linkList = '/issues/issue/' + getCurrentUserDefault().id;
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
    const [dataChanged, setDataChanged] = useState({});
    
    const userId = getCurrentUserDefault().id;
    const is_super_admin = getCurrentUserDefault().super_admin;

    const toast = useRef(null);

    const [listRef_id_chuc_nang, setListRef_id_chuc_nang] = useState([]);
    const [listRef_id_cong_viec, setListRef_id_cong_viec] = useState([]);
    const [listRef_id_nguoi_gap, setListRef_id_nguoi_gap] = useState([]);
    const [listRef_id_nguoi_phoi_hop, setListRef_id_nguoi_phoi_hop] = useState([]);
    const [listRef_id_nguoi_giai_quyet, setListRef_id_nguoi_giai_quyet] = useState([]);
    const [listRef_id_du_an, setListRef_id_du_an] = useState([]);
    const [id_du_an, setId_du_an] = useState(null);
    const { register, control, formState: { errors }, handleSubmit, reset, watch, getValues, setValue } = useForm({ defaultValues });
    const getFormErrorMessage = (name) => {
        return errors[name] && <small className="p-error">{errors[name].message}</small>
    };

    const show = () => {
        setTimeout(()=> {
            toast?.current?.show({ severity: 'success', summary: 'Submission Received', detail: 'Thành công' });
        },1000);
    };

    const onSubmit = async (formData) => {
        if (itemId === 'new') {
            await itemService.create(formData);
        } else {
            await itemService.update(itemId, formData);
            props.loadLazyData();
        }
        
        // if (props.fnLoadData) props.fnLoadData();
        if (props.fnClose) props.fnClose();
        else navigate(linkList);       
    }
    const getById = async (itemId) => {
        let result = await itemService.getById(itemId);
        if(!result.data.id_nguoi_gap) result.data.id_nguoi_gap=userId;
        if(!result.data.id_nguoi_phoi_hop) result.data.id_nguoi_phoi_hop=userId;
        if(!result.data.id_nguoi_giai_quyet) result.data.id_nguoi_giai_quyet=userId;
        reset(result.data);
    }
    useEffect(() => {
        if (itemId !== 'new') getById(itemId);
        getListRef_id_du_an();
        getListRef_id_chuc_nang();
        getListRef_id_nguoi_gap();
        getListRef_id_nguoi_phoi_hop();
        getListRef_id_nguoi_giai_quyet();
    }, [window.location.href, formData]);

    const getListRef_id_du_an = () => {
        return GC_CHUC_NANGService.getAllRef_id_du_an().then((res) => {
            res.data.map((x) => {
                x.Value = x.value;
                x.Text = x.label;
            });
            setListRef_id_du_an(res.data);
        });
    };
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
        if (props.fnClose) props.fnClose();
        else navigate(linkList);
        //navigate(-1);
    }
    return (
        <div>
            <Toast ref={toast} />
            <Card title={(itemId === 'new' ? 'Thêm' : 'Sửa') + ' Vấn đề cần giải quyết'}>
                <form className="p-fluid" onSubmit={handleSubmit((data) => {onSubmit(data); show();})}>
                    <div className='row mb-2'>
                        <Controller name="xxx" control={control} render={({ field, fieldState }) => (
                            <InputText {...field} className={'hide'} value={field.value} />
                        )} />

                        <div className="col-sm-6">
                            <label htmlFor="id_du_an">
                                {'Dự án'}
                            </label>
                            <Controller name="id_du_an" control={control} rules={{
                                //validate: value => value === 'pwd' || "The passwords do not match",
                                //pattern: {
                                //  value: /^[a-zA-Z]+$/,
                                //  message: 'pattern'
                                //},
                            }} render={({ field, fieldState }) => (
                                <Dropdown options={listRef_id_du_an} optionValue='Value' optionLabel='Text' scrollHeight={'600px'} className=''
                                    {...field}
                                    value={id_du_an ?? ''}
                                    onChange={(v)=>{
                                        console.log(v.target.value)
                                        setId_du_an(v.target.value);
                                    }}
                                    placeholder='--Chọn--'
                                    showClear
                                />
                            )} />
                            {getFormErrorMessage('id_du_an', errors)}
                        </div>
                        <div className="col-sm-6">
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
                                <Dropdown options={listRef_id_chuc_nang.filter(x=>x.id_du_an==id_du_an || id_du_an==null)} optionValue='Value' optionLabel='Text' scrollHeight={'600px'} className=''
                                    {...field}
                                    value={field.value ?? ''}
                                    placeholder='--Chọn--'
                                    showClear
                                />
                            )} />
                            {getFormErrorMessage('id_chuc_nang', errors)}
                        </div>
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
                                <InputText {...field} value={field.value ?? ''} />
                            )} />
                            {getFormErrorMessage('ten_van_de', errors)}
                        </div>
                        <div className="col-sm-6">
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
                                    value={field.value ?? ''}
                                    placeholder='--Chọn--'
                                    disabled
                                    showClear
                                />
                            )} />
                            {getFormErrorMessage('id_nguoi_gap', errors)}
                        </div>
                        <div className="col-sm-6">
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
                                    value={field.value ?? ''}
                                    placeholder='--Chọn--'
                                    disabled
                                    showClear
                                />
                            )} />
                            {getFormErrorMessage('id_nguoi_phoi_hop', errors)}
                        </div>
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
                                <CKEditor editor='content' id='content'
                                    config={{ height: 300 }}
                                    content={field.value}
                                    events={{
                                        'change': (event) => {
                                            field.onChange(event.editor.getData());
                                        }
                                    }}
                                    className={classNames({ 'p-invalid': fieldState.invalid })} />
                            )} />
                            {getFormErrorMessage('huong_giai_quyet', errors)}
                        </div>
                        <div className="col-sm-6">
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
                                <Dropdown options={listRef_id_nguoi_giai_quyet}
                                    optionValue='Value' optionLabel='Text'
                                    scrollHeight={'600px'} className=''
                                    {...field}
                                    value={field.value ?? ''}
                                    placeholder='--Chọn--'
                                    disabled
                                    showClear
                                />
                            )} />
                            {getFormErrorMessage('id_nguoi_giai_quyet', errors)}
                        </div>
                        <div className="col-sm-6">
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
                        <div className={props.fnClose ? 'text-center' : 'col-12'}>
                            <Button label={labelSave} icon='fa fa-save' style={{ width: '100px' }}   />
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

export default IssueForm
