import React, {  useEffect } from 'react';
import { useDispatch } from 'react-redux';
//import * as oauthAction  from 'store/oauth/oauthAction'
import { removeToken } from 'store/oauth/oauthSlice';
function Logout() {
  const dispatch = useDispatch();
  useEffect(() => { 
    console.log('logout');
    sessionStorage.setItem('aspSessionId', '');
    dispatch(removeToken());

    const timer = setTimeout(() => {
      // fix lỗi chung port logout không xoá token
      console.log('This will run after 1 second!');
      window.location.href='/';
    }, 1000);

    return () => clearTimeout(timer);
    // eslint-disable-next-line react-hooks/exhaustive-deps
}, []);

  return (
    <></>
  );
}
export default Logout;