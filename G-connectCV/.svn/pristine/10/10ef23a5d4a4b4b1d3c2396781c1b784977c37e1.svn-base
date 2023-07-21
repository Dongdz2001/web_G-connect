import axios from 'axios'
import { BaseService } from 'services/BaseService';
import { appSetting } from 'shared/app-settings';

let path = appSetting.PATH_APILMS_V2 + '/link-GC_CONG_VIEC'
class GC_CONG_VIECBaseService extends BaseService {
    constructor(props) {
        const _props = Object.assign({}, { url: appSetting.PATH_APILMS_V2 + '/link-GC_CONG_VIEC' }, props);
        super(_props);
    }

    getAllRef_id_chuc_nang() {
        return this.getAllRef('/link-GC_CHUC_NANG/select');
    }
    getAllRef_id_cong_viec_cha() {
        return this.getAllRef('/link-GC_CONG_VIEC/select');
    }
}
const GC_CONG_VIECService = new GC_CONG_VIECBaseService();
export { GC_CONG_VIECService };
