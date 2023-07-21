import React, { useEffect, useState, useRef } from 'react';
import { useForm, Controller } from 'react-hook-form';
import { InputText } from 'primereact/inputtext';
import { InputTextarea } from 'primereact/inputtextarea';
import { Button } from 'primereact/button';

import { classNames } from 'primereact/utils';
import { Card } from 'primereact/card';
import { locationService } from 'modules/location/locationService';
import { useParams } from 'react-router-dom';
import { InputSwitch } from 'primereact/inputswitch';
import { Dropdown } from 'primereact/dropdown';

import { useNavigate } from "react-router-dom";
import { useTranslation } from 'react-i18next'

import getFormErrorMessage from 'shared/components/getFormErrorMessage';
import sessionStorage from 'redux-persist/es/storage/session';

const LocationForm = () => {
    let navigate = useNavigate();
    const defaultValues = {
        name: '',
        address: '',
        manager_name: '',
        is_default: true
    }
    const { t, i18n } = useTranslation();
    let { location_id } = useParams();
    const [provinces, setProvinces] = useState([]);
    const { register, control, formState: { errors }, handleSubmit, reset, watch, getValues, setValue } = useForm({ defaultValues });
    const onSubmit = async (formData) => {
        formData.path_img = formData.img?.path;
        formData.Field = formData.FieldValue;
        if(location_id ==='new' ){
            //console.log(formData);
            await locationService.create(formData);
        }else{
            await locationService.update(location_id, formData);
        }
        navigate('/admin/location-list');
    }
    const getById = async (location_id)=>{
        let result = await locationService.getById(location_id);
        setProvinces(result.data.FieldValues);
        reset(result.data);
    }
    const loadProvince = async ()=>{
        let result = await locationService.getAllLocation();
        result.data.map(x => {
            x.id = x.VC_LCTN_ID;
            x.name = x.VC_LCTN_NM;
        });
        //setProvinces(result.data);
    }
    useEffect(() => {
        if(location_id !=='new' ) getById(location_id);
        loadProvince();       
    },[]);
    const close = async () => {
        navigate('/admin/location-list');
        //navigate(-1);
    }
    return (<Card title={t('rbkey_ct_ov111rvw', 'Thêm vị trí ')}>
        <form className="p-fluid container" onSubmit={handleSubmit(onSubmit)}>
            <div className='row'>
                <div className='col-12'>
                    <Button label={t('rbkey_ct_ov111rvw', 'Lưu')} icon='fa fa-save' style={{ width: '100px' }} />
                        
                    <Button className="btnClose" style={{width:100}} onClick={close.bind(this)} label={t('rbkey_ct_ov111rvw', 'Đóng')}></Button>
                </div>

                <Controller name="LocationId" control={control} render={({ field, fieldState }) => (
                    <InputText {...field} className={'hide'} value={location_id} />
                )} />
                <Controller name="Status" control={control} render={({ field, fieldState }) => (
                    <InputText {...field} className={'hide'} />
                )} />
                
                <div className="col-12">
                    <label htmlFor="name">
                        {t('rbkey_ct_ov111rvw', 'Vị trí')} 
                        &nbsp; <span className="p-error">*</span>
                    </label>
                    <Controller name="LocationName" control={control} rules={{ required: t('rbkey_ct_ov111rvw', 'Vui lòng nhập!') }} render={({ field, fieldState }) => (
                        <InputText {...field} className={classNames({ 'p-invalid': fieldState.invalid })} />
                    )} />
                    {getFormErrorMessage('name', errors)}
                </div>

                <div className="col-12">
                    <label htmlFor="address">
                        {t('rbkey_ct_ov111rvw', 'Mã vị trí')}
                    </label>
                    <Controller name="LocationCode" control={control} render={({ field, fieldState }) => (
                        <InputText {...field} value={field.value??''} />
                    )} />
                </div>
                <div className="col-12">
                    <label htmlFor="address">
                        {t('rbkey_ct_ov111rvw', 'Sự miêu tả')}
                    </label>
                    <Controller name="LocationDescription" control={control} render={({ field, fieldState }) => (
                        <InputTextarea {...field} value={field.value??''} />
                    )} />
                </div>
                <div className="col-12">
                    <label htmlFor="address">
                        {t('rbkey_ct_ov111rvw', 'Department')}
                    </label>
                    <Controller name="FieldValue" control={control} render={({ field, fieldState }) => (
                        <Dropdown options={provinces} optionValue='Value' optionLabel='Text' scrollHeight={'600px'} className='mr-2'
                            {...field}
                            placeholder='--Chọn--'
                            showClear
                        />
                    )} />
                </div>
                <div className="col-12">
                    <label htmlFor="address">
                        {t('rbkey_ct_ov111rvw', 'Số điện thoại')}
                    </label>
                    <Controller name="PhoneNo" control={control} render={({ field, fieldState }) => (
                        <InputText {...field} value={field.value??''} />
                    )} />
                </div>
                <div className="col-12">
                    <label htmlFor="address">
                        {t('rbkey_ct_ov111rvw', 'E-mail')}
                    </label>
                    <Controller name="Email" control={control} render={({ field, fieldState }) => (
                        <InputText {...field} value={field.value??''} />
                    )} />
                </div>
                <div className="col-12">
                    <label htmlFor="address">
                        {t('rbkey_ct_ov111rvw', 'Số nhà')}
                    </label>
                    <Controller name="HouseNo" control={control} render={({ field, fieldState }) => (
                        <InputText {...field} value={field.value??''} />
                    )} />
                </div>
                <div className="col-12">
                    <label htmlFor="address">
                        {t('rbkey_ct_ov111rvw', 'Đường')}
                    </label>
                    <Controller name="Street" control={control} render={({ field, fieldState }) => (
                        <InputText {...field} value={field.value??''} />
                    )} />
                </div>
                <div className="col-12">
                    <label htmlFor="address">
                        {t('rbkey_ct_ov111rvw', 'Địa phương')}
                    </label>
                    <Controller name="Locality" control={control} render={({ field, fieldState }) => (
                        <InputText {...field} value={field.value??''} />
                    )} />
                </div>
                <div className="col-12">
                    <label htmlFor="address">
                        {t('rbkey_ct_ov111rvw', 'Thành phố')}
                    </label>
                    <Controller name="City" control={control} render={({ field, fieldState }) => (
                        <InputText {...field} value={field.value??''} />
                    )} />
                </div>
                <div className="col-12">
                    <label htmlFor="address">
                        {t('rbkey_ct_ov111rvw', 'Bang / Vùng miền / Quốc gia')}
                    </label>
                    <Controller name="Region" control={control} render={({ field, fieldState }) => (
                        <InputText {...field} value={field.value??''} />
                    )} />
                </div>
                <div className="col-12">
                    <label htmlFor="address">
                        {t('rbkey_ct_ov111rvw', 'Quốc gia')}
                    </label>
                    <Controller name="Country" control={control} render={({ field, fieldState }) => (
                        <InputText {...field} value={field.value??''} />
                    )} />
                </div>
                <div className="col-12">
                    <label htmlFor="address">
                        {t('rbkey_ct_ov111rvw', 'Mã bưu điện')}
                    </label>
                    <Controller name="ZipCode" control={control} render={({ field, fieldState }) => (
                        <InputText {...field} value={field.value??''} />
                    )} />
                </div>
               
                <div className='col-12'>
                    <Button label={t('rbkey_ct_ov111rvw', 'Lưu')} icon='fa fa-save' style={{ width: '100px' }} />
                        
                    <Button className="btnClose" style={{width:100}} onClick={close.bind(this)} label={t('rbkey_ct_ov111rvw', 'Đóng')}></Button>
                </div>
            </div>
        </form>

    </Card>)
}
export default LocationForm;