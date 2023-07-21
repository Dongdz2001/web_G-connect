import axios from 'axios'
import { BaseService } from 'services/BaseService';
import { appSetting } from 'shared/app-settings';

let path = appSetting.PATH_APILMS_V2 + '/link-GC_LICH_HANG_NGAY'
class GC_LICH_HANG_NGAYBaseService extends BaseService {
    constructor(props) {
        const _props = Object.assign({}, { url: appSetting.PATH_APILMS_V2 + '/link-GC_LICH_HANG_NGAY' }, props);
        super(_props);
    }

    getAllRef_id_nguoi_thuc_hien() {
        return this.getAllRef('/link-qtht_nguoi_dung/select');
    }
    getAllRef_id_cong_viec() {
        return this.getAllRef('/link-GC_CONG_VIEC_PHAN_CONG/select');
    }
    checkIn() {
        return this.getAllRef('/link-GC_LICH_HANG_NGAY/checkIn');
    }
    checkOut() {
        return this.getAllRef('/link-GC_LICH_HANG_NGAY/checkOut');
    }
}
const GC_LICH_HANG_NGAYService = new GC_LICH_HANG_NGAYBaseService();
export { GC_LICH_HANG_NGAYService };
