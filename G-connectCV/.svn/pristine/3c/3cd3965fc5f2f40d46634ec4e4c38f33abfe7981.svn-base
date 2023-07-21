/* eslint-disable */
import axios from "axios";
import { store } from "../store";
import { appSetting } from "../shared/app-settings";
import { setToken, removeToken } from '../store/oauth/oauthSlice';
import { decodeHtmlEntites } from "./utils/decodeHtmlEntites";


let authTokenRequest = null;
function refreshToken(refreshToken) {
  let data =
    "grant_type=refresh_token&client_id=" +
    appSetting.CLIENT_ID +
    "&refresh_token=" +
    refreshToken;
  return axios.post("/connect/token",data, {
    headers: {
      "Content-Type": "application/x-www-form-urlencoded",
    },
  });
}

function getNewAccessToken(refresh_token) {
  //const refreshToken = window.localStorage.getItem("refreshToken");
  //const refreshToken = oauth.refresh_token;

  if (!authTokenRequest) {
    authTokenRequest = refreshToken(refresh_token);
    authTokenRequest.then(resetGetAccessTokenRequest,resetGetAccessTokenRequest);
  }

  return authTokenRequest;
}

function resetGetAccessTokenRequest() {
  authTokenRequest = null;
}

export default function registerAxiosInterceptor() {
  axios.defaults.baseURL = appSetting.API_URL;
  axios.interceptors.request.use(
    async function (config) {
      let oauth = store.getState().oauth;
      if (oauth !== null) {
        let token = oauth.token;
        //set token
        if (token) {
          config.headers.Authorization = `Bearer ${token}`;
        }
      }
      return config;
    },
    (err) => {
      return Promise.reject(err);
    }
  );

  axios.interceptors.response.use(    
    function (response) {
      // auto decode html entites
      if(response.status===200){
        //console.log('interceptors', response);
        let data = decodeHtmlEntites(response.data);
        response.data = data;
      }
      return response;
    },
    function (error) {
      const originalRequest = error.config;

      if (error.response.status === 401 && !originalRequest._retry) {
        originalRequest._retry = true;

        const refreshToken = store.getState().oauth.refresh_token;
        if(refreshToken!=null){
          return getNewAccessToken(refreshToken).then(res=>{
            store.dispatch(setToken(res.data));
            error.config.__isRetryRequest = true;
            return axios(error.config);
  
          }).catch(e=>{
            console.log('e',e);
             console.log('e.response.status',e.response.status);
             console.log('e.response.data',e.response.data);
            if(e.response.status===500){
              store.dispatch(removeToken());
              window.location = '/';
            }
          })
        }else{
          store.dispatch(removeToken());
          window.location = '/logout';
        }
      }
      else {
        if(error.response && error.response.status === 401 && (window.location.href.indexOf('-list') > 0 || window.location.href.indexOf('-form') > 0)) {
          store.dispatch(removeToken());
          window.location = '/logout';
        }
      }

      return Promise.reject(error);
    }
  );
}
