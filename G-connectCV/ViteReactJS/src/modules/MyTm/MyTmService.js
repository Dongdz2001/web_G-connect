import { BaseService } from 'services/BaseService';
import axios from 'axios'
import { appSetting } from 'shared/app-settings';

let path = appSetting.PATH_APILMS_V2 + '/forward/MyTm'
const MyTmService = {
    create(obj){
        return axios.post(path + '/create', obj);
    },  
    getById(id){
      return axios.get(path + '/getById?id='+ id);
    },
    update(id, obj){
        return axios.put(path + '/update?id=' + id, obj);
    },
    delete(id){
        return axios.delete(path + '/delete?id=' + id);
    },
    filterPage(advanceSearch){
        advanceSearch.sortField = null;
        advanceSearch.sortOrder = null;
        advanceSearch.rows = null;
        advanceSearch.refresh = null;
        let params = Object.keys(advanceSearch).map(key => advanceSearch[key] ? `${key}=${advanceSearch[key]}` : '').join('&');
        if(params.indexOf('&key_search=') < 0) params += '&key_search=';
        if(params.indexOf('&descending=') < 0) params += '&descending=true';
        let url = path + '/getData?' + params.substring(1).replace(/&&/g, '&').replace(/&&/g, '&').replace(/&&/g, '&').replace(/&&/g, '&').replace(/&&/g, '&');
        return axios.get(url);
    },
    getAll(){
        return axios.get(path + '/getAll');
    },
    getAllRef(path_api){
        return axios.get(appSetting.PATH_APILMS_V2 + path_api);
    },

}
export { MyTmService };