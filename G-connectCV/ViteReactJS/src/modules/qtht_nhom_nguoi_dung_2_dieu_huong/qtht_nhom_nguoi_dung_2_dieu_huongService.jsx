import axios from 'axios'
import { BaseService } from 'services/BaseService';
import { appSetting } from 'shared/app-settings';

let path = appSetting.PATH_APILMS_V2 + '/link-qtht_nhom_nguoi_dung_2_dieu_huong'
class qtht_nhom_nguoi_dung_2_dieu_huongBaseService extends BaseService {
    constructor(props) {
        const _props = Object.assign({}, { url: appSetting.PATH_APILMS_V2 + '/link-qtht_nhom_nguoi_dung_2_dieu_huong' }, props);
        super(_props);
    }

    getAllRef_nhom_nguoi_dung_id() {
        return this.getAllRef('/link-qtht_nhom_nguoi_dung/select');
    }
    getAllRef_dieu_huong_id() {
        return this.getAllRef('/link-qtht_dieu_huong/select');
    }
}
const qtht_nhom_nguoi_dung_2_dieu_huongService = new qtht_nhom_nguoi_dung_2_dieu_huongBaseService();
export { qtht_nhom_nguoi_dung_2_dieu_huongService };
