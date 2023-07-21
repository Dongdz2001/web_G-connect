import axios from 'axios'
import { BaseService } from 'services/BaseService';
import { appSetting } from 'shared/app-settings';

let path = appSetting.PATH_APILMS_V2 + '/link-qtht_nguoi_dung_2_nhom_nguoi_dung'
class qtht_nguoi_dung_2_nhom_nguoi_dungBaseService extends BaseService {
    constructor(props) {
        const _props = Object.assign({}, { url: appSetting.PATH_APILMS_V2 + '/link-qtht_nguoi_dung_2_nhom_nguoi_dung' }, props);
        super(_props);
    }

    getAllRef_nguoi_dung_id() {
        return this.getAllRef('/link-qtht_nguoi_dung/select');
    }
    getAllRef_nhom_nguoi_dung_id() {
        return this.getAllRef('/link-qtht_nhom_nguoi_dung/select');
    }
}
const qtht_nguoi_dung_2_nhom_nguoi_dungService = new qtht_nguoi_dung_2_nhom_nguoi_dungBaseService();
export { qtht_nguoi_dung_2_nhom_nguoi_dungService };
