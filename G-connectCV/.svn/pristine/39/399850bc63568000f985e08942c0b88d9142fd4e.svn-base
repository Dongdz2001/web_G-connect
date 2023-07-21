import { BaseService } from 'services/BaseService';
import axios from 'axios'
import { appSetting } from 'shared/app-settings';

let path = appSetting.PATH_APILMS_V2 + '/AdminNew'
const qtht_don_viService = {
    create(obj){
        return axios.post(path + '/create', obj);
    },  
    getById(id){
      return axios.get(path + '/getUserById?id='+ id);
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
        let url = path + '/getUserData?' + params.substring(1).replace(/&&/g, '&').replace(/&&/g, '&').replace(/&&/g, '&').replace(/&&/g, '&').replace(/&&/g, '&');
        return axios.get(url);
    },
    getAll(){
        return axios.get(path + '/getAll');
    },
    getAllRef(path_api){
        return axios.get(appSetting.PATH_APILMS_V2 + path_api);
    },

    getAllRef_nguoi_tao_id() {
        return this.getAllRef('/AdminNew/getAllLocation');
    },
    getAllRef_nguoi_chinh_sua_id() {
        return this.getAllRef('/AdminNew/getAllLocation');
    },
    getAllRef_don_vi_cap_tren_id() {
        return this.getAllRef('/AdminNew/getAllLocation');
    },
}
export { qtht_don_viService };

class qtht_don_viBaseService extends BaseService {
    constructor(props) {
        const _props = Object.assign({}, { url: appSetting.PATH_APILMS_V2 + '/AdminNew' }, props);
        super(_props);
    }

    getAllRef_nguoi_tao_id() {
        return this.getAllRef('/link-qtht_nguoi_dung/getAll');
    }
    getAllRef_nguoi_chinh_sua_id() {
        return this.getAllRef('/link-qtht_nguoi_dung/getAll');
    }
    getAllRef_don_vi_cap_tren_id() {
        return this.getAllRef('/link-qtht_don_vi/getAll');
    }
}
const qtht_don_viService1 = new qtht_don_viBaseService();
export { qtht_don_viService1 };
