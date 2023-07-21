import { useEffect, useState  } from 'react';
import { authRouters } from '../routers/authRouters';
import registerAxiosInterceptor from '../shared/interceptor';
import { Outlet, Route, Routes, Navigate, useNavigate } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import { ConfirmDialog } from 'primereact/confirmdialog';

function getParameterByName(name, url = window.location.href) {
  //name = name;
  //url = window.location.href;
  var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
    results = regex.exec(url);
  if (!results) return '';
  if (!results[2]) return '';
  return decodeURIComponent(results[2].replace(/\+/g, ' '));
}

function AuthLayout() {
  const dispatch = useDispatch();
  let navigate = useNavigate();
  const [tm, setTm] = useState(null);
  
  //1. setup axios default interceptor
  registerAxiosInterceptor();

  useEffect(() => {
    //set time logout tren old lms
    setTm(Math.floor(Date.now() / 1000));

  }, []);

  return (
    <>
      <ConfirmDialog header="Thông báo" />
      <Routes>

        {authRouters.map(({ path, component: Component }, index) =>
          //console.log(route)
          <Route path={path} key={index} element={<Component />} />
        )}
        <Route path="*" element={<Navigate to="/overview" />} />
      </Routes>
      <Outlet />
    </>
  )

}
export default AuthLayout;
