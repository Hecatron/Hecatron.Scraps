import { Component, Vue } from 'vue-property-decorator';
import HeaderComponent from './header.vue';
import FooterComponent from './footer.vue';
import StaticpageComponent from '../staticpage.vue';

@Component({
    components: {
        HeaderComponent,
        FooterComponent,
        StaticpageComponent
    },
})
export default class DashBoardComponent extends Vue {
}
