import axios from 'axios'
import { BaseService } from 'services/BaseService';
import { appSetting } from 'shared/app-settings';

let path = appSetting.PATH_APILMS_V2 + '/link-qtht_cau_hinh_ma'
class qtht_cau_hinh_maBaseService extends BaseService {
    constructor(props) {
        const _props = Object.assign({}, { url: appSetting.PATH_APILMS_V2 + '/link-qtht_cau_hinh_ma' }, props);
        super(_props);
    }

}
const qtht_cau_hinh_maService = new qtht_cau_hinh_maBaseService();
export { qtht_cau_hinh_maService };
