import axios from 'axios'
import { BaseService } from 'services/BaseService';
import { appSetting } from 'shared/app-settings';

let path = appSetting.PATH_APILMS_V2 + '/link-GC_DM_LOAI_DU_AN'
class GC_DM_LOAI_DU_ANBaseService extends BaseService {
    constructor(props) {
        const _props = Object.assign({}, { url: appSetting.PATH_APILMS_V2 + '/link-GC_DM_LOAI_DU_AN' }, props);
        super(_props);
    }

}
const GC_DM_LOAI_DU_ANService = new GC_DM_LOAI_DU_ANBaseService();
export { GC_DM_LOAI_DU_ANService };
