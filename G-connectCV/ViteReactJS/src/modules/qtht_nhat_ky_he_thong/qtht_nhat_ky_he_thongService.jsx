import axios from 'axios'
import { BaseService } from 'services/BaseService';
import { appSetting } from 'shared/app-settings';

let path = appSetting.PATH_APILMS_V2 + '/link-qtht_nhat_ky_he_thong'
class qtht_nhat_ky_he_thongBaseService extends BaseService {
    constructor(props) {
        const _props = Object.assign({}, { url: appSetting.PATH_APILMS_V2 + '/link-qtht_nhat_ky_he_thong' }, props);
        super(_props);
    }

    getAllRef_nguoi_thuc_hien_id() {
        return this.getAllRef('/link-qtht_nguoi_dung/select');
    }
}
const qtht_nhat_ky_he_thongService = new qtht_nhat_ky_he_thongBaseService();
export { qtht_nhat_ky_he_thongService };
