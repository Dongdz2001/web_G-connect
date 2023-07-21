import axios from 'axios'
import { jsonToUrlencoded } from 'shared/utils';
import { appSetting, AUTHORIZATION_BASE } from 'shared/app-settings';
 
axios.defaults.baseURL = appSetting.API_URL;
const oauthService = {
    login(params){
        let data = "grant_type=password&client_id="+appSetting.CLIENT_ID+"&username=" + params.username + "&password=" + params.password;
        data = data + '&keep_login='+ params.keep_login;
        data = data + '&client_secret='+ appSetting.CLIENT_SECRET;
        return axios.post('/connect/token', data, {
            headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
            }
        });
    },  
    
    refreshToken(param_refresh_token){
        let data = "grant_type=refresh_token&client_id=" + appSetting.CLIENT_ID + "&refresh_token=" + param_refresh_token
        return axios.post('/auth/login', data, {
          headers: {
            'Content-Type': 'application/x-www-form-urlencoded',
          }
        });
    },  
    
    toHex(str) {
      var result = '';
      for (var i = 0; i < str.length; i++) {
          result += str.charCodeAt(i).toString(16);
      }
      return result;
    },
    encrypt(p1) {
      for (var i = 0; i < 10; i++) {
          p1 = window.btoa(p1);
      }
      p1 = this.toHex(p1);
      p1 = p1.replace(/a/g, 'z');
      p1 = p1.replace(/b/g, 'x');
      p1 = p1.replace(/c/g, 'y');
      p1 = p1.replace(/d/g, 'k');
      p1 = p1.replace(/e/g, 'l');
      p1 = p1.replace(/f/g, 'm');
      return p1;
    },
    loginLMS(data){
      console.log('loginLMS');
      const body = jsonToUrlencoded({
          grant_type: 'password',
          username: data.username,
          password: data.password
      });
      console.log('loginLMS', body);
      return axios.post(appSetting.API_URL + 'connect/token', body, {
        headers: {
          'Content-Type': 'application/x-www-form-urlencoded',
          'Authorization': AUTHORIZATION_BASE
        }
      });
    }

}
export { oauthService };
