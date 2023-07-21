import { useEffect, useRef  } from 'react'
import { Card } from 'primereact/card';
import { TabView, TabPanel } from 'primereact/tabview';
import { useForm, Controller } from 'react-hook-form';
import { Button } from 'primereact/button';
import { InputText } from 'primereact/inputtext';
import { classNames } from 'primereact/utils';
import { userService } from 'modules/user/userService';
import { useSelector } from 'react-redux';
import { Calendar } from 'primereact/calendar';
import { Password } from 'primereact/password';
import dayjs from 'dayjs';
import { Toast } from 'primereact/toast';
import { oauthService } from 'services/oauthService';
import { getCurrentUserDefault } from "shared/utils/getCurrentUserDefault";

const ChangePassword = () => {
    const toastBR = useRef(null);
    const defaultValues = {
        user_id: '',
        oldpassword: '',
        password: '',
        confirm_password: '',
    }
    const currentUser = useSelector(state => state.oauth.currentUser);
    const tai_khoan = getCurrentUserDefault().tai_khoan;

    const getFormErrorMessage = (name) => {
        return errors[name] && <small className="p-error">{errors[name].message}</small>
    };
    const onSubmit = async (values) => {
        try{
            console.log(values)
            var data = {username:tai_khoan,password:values.oldpassword,keep_login:false};
            userService.checkpassword(values.oldpassword).then((auth)=>{
                let result = userService.changepassword(values.password);
                console.log(result);
                toastBR.current.show({severity:'success', summary: 'Success Message', detail:'Message Content', life: 3000});
            }).catch(err=>{
                toastBR.current.show({severity:'error', summary: 'Message', detail:'Mật khẩu cũ không đúng', life: 3000});
              });
        }catch(e){
            console.log(e.response.data);
            toastBR.current.show({severity:'error', summary: 'Message', detail:e.response.data, life: 3000});
        }
    }
    const { register, control, formState: { errors }, handleSubmit, reset, watch, getValues, setValue } = useForm({ defaultValues });
    const getUserById = async (userId) => {
       
        let result = await userService.getById(userId);
        result.data.user_id = userId;
        reset(result.data)
        
    }
    useEffect(() => {

    }, []);

    return (<>
        <Toast ref={toastBR} position="bottom-right" />
        <form className="p-fluid" onSubmit={handleSubmit(onSubmit)}>
            <div className="field">
                <label htmlFor="oldpassword">Mật khẩu cũ</label>
                <Controller name="oldpassword" control={control} rules={{ required: 'OldPassword is required.' }} render={({ field, fieldState }) => (
                    <Password id={field.oldpassword} {...field} feedback={false} toggleMask className={classNames({ 'p-invalid': fieldState.invalid })} />
                )} />
                {getFormErrorMessage('oldpassword')}
            </div>

            <div className="field">
                <label htmlFor="password">Mật khẩu mới</label>
                <Controller name="password" control={control} rules={{ required: 'Password is required.' }} render={({ field, fieldState }) => (
                    <Password id={field.password} {...field} feedback={false} toggleMask className={classNames({ 'p-invalid': fieldState.invalid })} />
                )} />
                {getFormErrorMessage('password')}
            </div>
            <div className="field">
                <label htmlFor="email">Nhắc lại mật khẩu mới</label>
                <Controller name="confirm_password" control={control}
                    rules={{
                        required: 'Password is required.', validate: value => {
                            return value === getValues('password') || 'The confirm password do not match'
                        }
                    }} render={({ field, fieldState }) => (
                        <Password id={field.confirm_password} {...field} feedback={false} toggleMask className={classNames({ 'p-invalid': fieldState.invalid })}

                        />
                    )} />
                {getFormErrorMessage('confirm_password')}
            </div>
            <div style={{textAlign: 'center'}}>
                <Button type="submit" label="Save" className="mt-2" style={{ width: 100 }} />
            </div>
        </form>
    </>)
}
export default ChangePassword;