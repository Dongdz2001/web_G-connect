import { useEffect } from 'react'
import { Card } from 'primereact/card';
import { TabView, TabPanel } from 'primereact/tabview';
import { useForm, Controller } from 'react-hook-form';
import { Button } from 'primereact/button';
import { InputText } from 'primereact/inputtext';
import { classNames } from 'primereact/utils';
import { userService } from 'modules/user/userService';
import { useSelector } from 'react-redux';
import { Calendar } from 'primereact/calendar';
import { confirmDialogGlobal } from 'shared/components/confirmDialogGlobal';
import ChangePassword from './ChangePassword';
import { useNavigate } from 'react-router-dom';
import dayjs from 'dayjs';
import { Link } from "react-router-dom";
import { getCurrentUserDefault } from "shared/utils/getCurrentUserDefault";

const Profile = (props) => {
    let navigate = useNavigate();
    const labelClose = "Đóng";
    const defaultValues = {
        user_name: '',
        full_name: '',
        email: '',
        password: '',
        confirm_password:'',
        date_of_birth: null,
        list_role: []
        
    }
    const currentUser = useSelector(state => state.oauth.currentUser);

    const user_id = getCurrentUserDefault().id;

    const getFormErrorMessage= (name) => {
        return errors[name] && <small className="p-error">{errors[name].message}</small>
    };
    const onSubmit = async (values) => {
        await userService.update(values);
    }
    const { register, control, formState: { errors }, handleSubmit, reset, watch, getValues, setValue } = useForm({ defaultValues });
    const  getUserById = async (userId)=>{
        let result = await userService.getById(userId);
        reset(result.data)
    }
    const close = async () => {
      if (props.fnClose) props.fnClose();
    };
    const logoutAllDevices = async ()=>{
        await userService.logoutAllDevices();
        navigate('/admin/logout');
      }
    const confirmLogout = (data) => {
        //console.log(confirmDialog);
        confirmDialogGlobal({
            message: 'Bạn có muốn đăng xuất khỏi tất cả các thiết bị?',
            accept: ()=>logoutAllDevices()
        });
    };
    useEffect(() => {
        getUserById(currentUser ? currentUser.user_id : user_id);
    }, []);
    return (<Card title='Thông tin tài khoản'>
        <TabView>
            <TabPanel header="Thông tin">
                <form className="p-fluid" onSubmit={handleSubmit(onSubmit)}>
                        <div className="field">
                            <label htmlFor="tai_khoan">Tên tài khoản</label>
                            <Controller name="tai_khoan" control={control}  render={({ field, fieldState }) => (
                                <InputText disabled id={field.tai_khoan} {...field} autoFocus className={classNames({ 'p-invalid': fieldState.invalid })} />
                            )} />
                            {getFormErrorMessage('tai_khoan')}
                        </div>

                        <div className="field">
                            <label htmlFor="ten">Tên đầy đủ</label>
                            <Controller name="ten" control={control} rules={{ required: 'Trường không được để trống!' }} render={({ field, fieldState }) => (
                                <InputText id={field.ten} {...field} value={field.value ?? ''} className={classNames({ 'p-invalid': fieldState.invalid })} />
                            )} />
                            {getFormErrorMessage('ten')}
                        </div>
                        <div className="field">
                            <label htmlFor="email">Email</label>
                            <Controller name="email" control={control} rules={{ required: 'Trường không được để trống!',pattern: { value: /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i, message: 'Invalid email address. E.g. example@email.com' } }} render={({ field, fieldState }) => (
                                <InputText id={field.full_name} {...field} value={field.value ?? ''} className={classNames({ 'p-invalid': fieldState.invalid })} />
                            )} />
                            {getFormErrorMessage('email')}
                        </div>
                        <div style={{textAlign: 'center'}}>
                            <Button type="submit" label="Save" className="mt-2" style={{ width: 100 }} />
                            <Link to={null} onClick={close.bind(this)}>
                                <Button className="btnClose"style={{ width: 100 }} label={labelClose} />
                            </Link>
                        </div>
                    </form>
            </TabPanel>
            <TabPanel header="Đổi mật khẩu">
               <ChangePassword/>
            </TabPanel>
            <TabPanel header="Bảo mật">
                <div style={{textAlign: 'center'}}>
                    <Button onClick={()=>confirmLogout()}>Đăng xuất khỏi tất cả các thiết bị</Button>
                </div>
            </TabPanel>
            
        </TabView>
    </Card>)
}
export default Profile;