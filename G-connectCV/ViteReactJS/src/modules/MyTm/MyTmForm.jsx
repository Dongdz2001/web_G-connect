import React, { useEffect, useState, useRef } from 'react';
import dayjs from 'dayjs';
import utc from 'dayjs/plugin/utc'
import { useForm, Controller } from 'react-hook-form';
import { InputText } from 'primereact/inputtext';
import { InputTextarea } from 'primereact/inputtextarea';
import { MultiStateCheckbox } from 'primereact/multistatecheckbox';
import { RadioButton } from 'primereact/radiobutton';
import { Button } from 'primereact/button';
import CkEditor from 'components/ckeditor4/CkEditor';
import { postStatusText, statusText, ACTIVE, DEACTIVE } from 'shared/utils/appState';
import { SelectImgItem } from 'components/SelectImgItem';
import { Checkbox } from "primereact/checkbox";
import { Link } from 'react-router-dom';
import { SelectButton } from 'primereact/selectbutton';
import { AutoComplete } from 'primereact/autocomplete';
import { Calendar } from 'components/Calendar';
import { Dialog } from 'primereact/dialog';
import { classNames } from 'primereact/utils';
import { Card } from 'primereact/card';
import { useParams } from 'react-router-dom';
import { InputSwitch } from 'primereact/inputswitch';
import { Dropdown } from 'primereact/dropdown';
import arrow from 'assets/arrow.png';

import { useNavigate } from "react-router-dom";
import { useTranslation } from 'react-i18next'
import { decodeUnicode, formatResourceLanguage } from 'shared/utils/decodeHtmlEntites';
import getFormErrorMessage from 'shared/components/getFormErrorMessage';
import sessionStorage from 'redux-persist/es/storage/session';

import { MyTmService } from 'modules/MyTm/MyTmService';

dayjs.extend(utc)
const MyTmForm = () => {
    const { t, i18n } = useTranslation();
    let { id } = useParams();
    let itemId = id;
    const linkList = '/admin/MyTm';
    const linkEdit = '/admin/MyTm-form';
    const labelSave = 'Lưu';
    const labelClose = 'Đóng';
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
            await MyTmService.create(formData);
        } else {
            await MyTmService.update(itemId, formData);
        }
        navigate(linkList);
    }
    const getById = async (itemId)=>{
        let result = await MyTmService.getById(itemId);
        reset(result.data);
    }
    useEffect(() => {
        if(itemId !=='new') getById(itemId);
        else {
            setTimeout(()=>reset({}), 20);
            reset({});
        }

    },[window.location.href]);

    const clearAll = async () => {
        setTimeout(()=>reset({}), 20);
        reset({});
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

            <Card title={(itemId === 'new' ? '' : '') + t('', '')}>
                <div className='row row-button' style={{ textAlign: 'right' }}>
                    <div className='col-12'>

                    </div>
                </div>
                <form className="p-fluid container" onSubmit={handleSubmit(onSubmit)}>
                    <div className='row row-button'>
                        <div className='col-12'>
                            <ul id="myTab" className="nav nav-tabs">

                            </ul>
                        </div>
                    </div>
                    <div className='row'>
                        <div className='col-12 row-button'>

                            <Button className="btnClose" style={{width:100}} icon='fa fa-close' onClick={close.bind(this)} label={labelClose}></Button>
                        </div>
                        <br/><br/>

                        <Controller name="xxx" control={control} render={({ field, fieldState }) => (
                            <InputText {...field} className={'hide'} value={field.value} />
                        )} />


                        <div className='col-12 row-button'>

                            <Button className="btnClose" style={{width:100}} icon='fa fa-close' onClick={close.bind(this)} label={labelClose}></Button>
                        </div>
                    </div>
                </form>

            </Card>
        </div>
    )
}
export default MyTmForm;