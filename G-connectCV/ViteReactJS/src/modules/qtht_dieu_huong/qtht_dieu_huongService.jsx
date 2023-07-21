import axios from 'axios'
import { BaseService } from 'services/BaseService';
import { appSetting } from 'shared/app-settings';

let path = appSetting.PATH_APILMS_V2 + '/link-qtht_dieu_huong'
class qtht_dieu_huongBaseService extends BaseService {
    constructor(props) {
        const _props = Object.assign({}, { url: appSetting.PATH_APILMS_V2 + '/link-qtht_dieu_huong' }, props);
        super(_props);
    }

}
const qtht_dieu_huongService = new qtht_dieu_huongBaseService();
export { qtht_dieu_huongService };
