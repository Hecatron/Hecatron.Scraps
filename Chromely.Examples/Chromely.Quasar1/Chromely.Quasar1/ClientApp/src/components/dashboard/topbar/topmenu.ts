import { Component, Vue } from 'vue-property-decorator';

@Component
export default class TopmenuComponent extends Vue {

    private Open_Click() {
        this.$q.dialog({
            title: 'Open Clicked',
            message: 'Open Clicked'
        });
    }

    private New_Click() {
        this.$q.dialog({
            title: 'New Clicked',
            message: 'New Clicked'
        });
    }

    private Quit_Click() {
        this.$q.dialog({
            title: 'Quit Clicked',
            message: 'Quit Clicked'
        });
    }
}
