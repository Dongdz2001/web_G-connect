import axios from 'axios'
import { BaseService } from 'services/BaseService';
import { appSetting } from 'shared/app-settings';

let path = appSetting.PATH_APILMS_V2 + '/link-GC_CONG_VIEC_PHAN_CONG'
class GC_CONG_VIEC_PHAN_CONGBaseService extends BaseService {
    constructor(props) {
        const _props = Object.assign({}, { url: appSetting.PATH_APILMS_V2 + '/link-GC_CONG_VIEC_PHAN_CONG' }, props);
        super(_props);
    }

    getAllRef_id_chuc_nang() {
        return this.getAllRef('/link-GC_CHUC_NANG/select');
    }
    getAllRef_id_cong_viec() {
        return this.getAllRef('/link-GC_CONG_VIEC/select');
    }
    getAllRef_id_trang_thai() {
        return this.getAllRef('/link-GC_DM_TRANG_THAI/select');
    }
    getAllRef_id_nguoi_thuc_hien() {
        return this.getAllRef('/link-qtht_nguoi_dung/select');
    }
    getAllRef_id_nguoi_phoi_hop() {
        return this.getAllRef('/link-qtht_nguoi_dung/select');
    }
    getAllRef_id_nguoi_duyet() {
        return this.getAllRef('/link-qtht_nguoi_dung/select');
    }
}
const GC_CONG_VIEC_PHAN_CONGService = new GC_CONG_VIEC_PHAN_CONGBaseService();
export { GC_CONG_VIEC_PHAN_CONGService };
