import axios from 'axios'
import { appSetting } from 'shared/app-settings';

let path = appSetting.PATH_APILMS_V2 + '/AdminNew'
const locationService = {
    create(obj){
        return axios.post(path + '/createLocation', obj);
    },  
    getById(id){
      return axios.get(path + '/getLocationById?id='+ id);
    },
    update(id, obj){
        return axios.put(path + '/updateLocation?id=' + id, obj);
    },
    delete(id){
        return axios.delete(path + '/deleteLocation?id=' + id);
    },
    filterPage(advanceSearch){
        const items_per_page = advanceSearch.items_per_page
        const current_page = advanceSearch.current_page
        const sort_by = advanceSearch.sort_by
        const descending = advanceSearch.descending
        const key_search = advanceSearch.key_search
        let url = path+ '/getLocationData?items_per_page=' + items_per_page
        url += '&current_page=' + current_page
        url += '&sort_by=' + sort_by
        url += '&key_search=' + key_search
        url += '&descending=' + descending
        return axios.get(url);
    },
    getAllLocation(){
        return axios.get(path + '/getAllLocation');
    }
    
}
export { locationService };
