import React, { useEffect, useState, useRef } from 'react';
import { useForm, Controller } from 'react-hook-form';
import { InputText } from 'primereact/inputtext';
import { Button } from 'primereact/button';
import { classNames } from 'primereact/utils';
import { Card } from 'primereact/card';
import { BaseService } from 'services/BaseService';
import { useParams } from 'react-router-dom';
import { InputSwitch } from 'primereact/inputswitch';
import { Dropdown } from 'primereact/dropdown';
import { useNavigate } from "react-router-dom";
import getFormErrorMessage from 'shared/components/getFormErrorMessage';

const ProvinceForm = () => {
    let navigate = useNavigate();
    const [provinces, setProvinces] = useState([]);
    const defaultValues = {
        name: '',
        code: '',
        description: '',
        state: true,
        province_id:''
    }
    let { district_id } = useParams();
    const { register, control, formState: { errors }, handleSubmit, reset, watch, getValues, setValue } = useForm({ 
        mode: "onBlur",
        defaultValues: defaultValues
     });
    const onSubmit = async (formData) => {
        formData.path_img = formData.img?.path;
        if(district_id ==='new' ){
            //console.log(formData);
        }
        navigate('/admin/district-list');
    }
    const getById = async (district_id)=>{
    }
    const loadProvince = async ()=>{
    }
    useEffect(() => {
        if(district_id !=='new' ) getById(district_id);
        loadProvince();
    },[]);
    return (<Card title='Quận/huyện'>
        <form className="p-fluid container" onSubmit={handleSubmit(onSubmit)}>
            <div className='row'>
                <div className='col-12'>
                    <Button label='Lưu' icon='fa fa-save' style={{ width: '100px' }} />
                </div>
                <div className="col-6">
                    <label htmlFor="name">
                        Tên
                    </label>
                    <Controller name="name" control={control} rules={{ required: 'Vui lòng nhập!' }} render={({ field, fieldState }) => (
                        <InputText {...field} className={classNames({ 'p-invalid': fieldState.invalid })} 
                        />
                    )} />

                    {getFormErrorMessage('name', errors)}
                </div>

                <div className="col-6">
                    <label htmlFor="address">
                        Mã
                    </label>
                    
                    <Controller name="code" control={control} rules={{ required: 'Vui lòng nhập!' }} render={({ field, fieldState }) => (
                        <InputText  {...field} className={classNames({ 'p-invalid': fieldState.invalid })}  
                            {...register("code", {
                                validate: async (value) => {
                                }
                            })}
                          />
                    )} />
                    {getFormErrorMessage('code', errors)}
                </div>
                <div className="col-6">
                    <label htmlFor="address">
                        Tỉnh/thành phố
                    </label>
                    
                    <Controller name="province_id" control={control} rules={{ required: 'Vui lòng chọn!' }} render={({ field, fieldState }) => (
                        <Dropdown options={provinces} optionValue='id' optionLabel='name' scrollHeight={'600px'} className='mr-2'
                        {...field}
                        placeholder='--Chọn--'
                        showClear
                    />
                    )} />
                    {getFormErrorMessage('province_id', errors)}
                </div>
               
                <div className="col-12">
                    <label htmlFor="description">
                        Mô tả
                    </label>
                    <Controller name="description" control={control} render={({ field, fieldState }) => (
                        <InputText {...field} value={field.value??''} />
                    )} />
                   
                </div>
                
                <div className='col-12'>
                    <label htmlFor="state">Sử dụng/ Không sử dụng</label><br/>
                    <Controller name="state" control={control} render={({ field, fieldState }) => (
                         <InputSwitch checked={field.value} onChange={(e) => field.onChange(e.target.value)} />
                    )} />
                </div>
            </div>
        </form>

    </Card>)
}
export default ProvinceForm;