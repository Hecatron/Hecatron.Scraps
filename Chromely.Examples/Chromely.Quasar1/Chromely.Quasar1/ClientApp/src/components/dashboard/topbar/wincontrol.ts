import { Component, Vue } from 'vue-property-decorator';

@Component
export default class WincontrolComponent extends Vue {

    private isMaximised: boolean = false;

    public toggleMaxRestore() {
        if (this.isMaximised)
            this.restoreWindow();
        else
            this.maximiseWindow();
    }

    private maximiseWindow() {
        fetch('/chromely/window/maximize')
            .then((response) => response.json() as Promise<boolean>)
            .then((data) => {
                if (data === true) {
                    this.isMaximised = true;
                }
            });
    }

    private restoreWindow() {
        fetch('/chromely/window/restore')
            .then((response) => response.json() as Promise<boolean>)
            .then((data) => {
                if (data === true) {
                    this.isMaximised = false;
                }
            });
    }

    private minimiseWindow() {
        fetch('/chromely/window/minimize');
    }

    private closeWindow() {
        fetch('/chromely/window/close');
    }
}
