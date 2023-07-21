import { loadable } from 'shared/utils';

const demoRoutes = [
    
    {
        path: '/demotest',
        component: loadable(() => import('./components/DemoTest'))
    },
    {
        path:'/lms-container',
        component: loadable(() => import('./components/LMSContainer'))
    },
    {
        path:'/columnchart',
        component: loadable(() => import('./components/ColumnChartDemo'))
    },
    {
        path:'/gaugechart',
        component: loadable(() => import('./components/GaugeChartDemo'))
    },
    {
        path:'/dragdrop',
        component: loadable(() => import('./components/DragDropDemo'))
    },
    {
        path:'/dragdrophook',
        component: loadable(() => import('./components/DragDropHookList'))
    },
    {
        path:'/cardresponsive',
        component: loadable(() => import('./components/DemoCardResponive'))
    },
    {
        path:'/calendar',
        component: loadable(() => import('./components/DemoCalendar'))
    },
    {
        path:'/fixscroll',
        component: loadable(() => import('./components/FixScrollDemo'))
    },
    {
        path:'/hooklist',
        component: loadable(() => import('./components/DemoHookListSate'))
    },
    
]
export { demoRoutes };