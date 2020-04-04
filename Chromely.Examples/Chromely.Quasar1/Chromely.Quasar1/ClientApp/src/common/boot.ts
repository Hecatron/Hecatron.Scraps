import { Component, Vue } from 'vue-property-decorator';

// Router Support
import VueRouter from 'vue-router';
Vue.use(VueRouter);

// Import webfont mdi icons
import '@mdi/font/css/materialdesignicons.css';

// Quasar frontend
import 'quasar/dist/quasar.css';
import iconSet from 'quasar/icon-set/mdi-v5';
import Quasar from 'quasar';
Vue.use(Quasar, {
        iconSet: iconSet
    }
);

// Destnation routes for different urls
import { routes } from './routes';

// Enable dark mode
// Note the sidebar menu needs to be made dark separately via content-class
import { Dark } from 'quasar';
Dark.set(true);

// Disable the annoying production / development warning
Vue.config.productionTip = false;

// Root component
@Component({
    render: (h: any) => h(require('../components/dashboard/dashboard.vue').default),
    router: new VueRouter({ mode: 'history', routes }),
})
export default class BootComponent extends Vue {
}

// see https://vuejs.org/v2/api/#vm-mount for root component
new BootComponent().$mount('#q-app');
