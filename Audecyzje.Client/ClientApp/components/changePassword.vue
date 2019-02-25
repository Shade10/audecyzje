<template>
    <div class="container">
        <div class="col-6 py-5 mx-auto">
            <h2 class="mb-2">Zmiana hasła użytkownika</h2>
            <form @submit.prevent="validdateChangePassword" autocomplete="off">
                <div class="form-group with-icon-right">
                    <div class="input-group">
                        <label for="Email">Email</label>
                        <input id="email" name="email" v-model="user.Email" class="form-control" required />
                    </div>
                </div>
                <div class="input-fields">
                    <label for="password">Stare Hasło</label>
                    <input v-validate="'required'" v-model="user.Password" name="password" type="password" class="form-control" placeholder="Password" ref="password">

                    <label for="password">Stare Hasło</label>
                    <input v-validate="'required|confirmed:password'" name="password_confirmation" type="password" class="form-control" placeholder="Password, Again" data-vv-as="password">
                </div>

                <div class="alert alert-danger" v-show="errors.any()">
                    <div v-if="errors.has('password')">
                        {{ errors.first('password') }}
                    </div>
                    <div v-if="errors.has('password_confirmation')">
                        {{ errors.first('password_confirmation') }}
                    </div>
                </div>

                <button type="submit" class="btn btn-primary">
                    Validate!
                </button>
            </form>
        </div>
    </div>

</template>

<script>
    import { validator } from 'vee-validate';
    Vue.use(validator);

    export default {
        name: 'changePassword',

        data() {
            return {
                user: {
                    Email: "",
                    Password: ''
                },
                hasErrors: false,
                newPassword: "",
                errors: "",
            };
        },

        methods: {
            //async changePassword() {
            //    try {
            //        this.hasErrors = false;
            //        const { Email, Password } = this.user;

            //        const { data } = await this.$http.post('/api/account/changePassword', { Email: Email, currentPassword: Password, newPassword: this.newPassword })
            //        let redirectTo = '/admin/'
            //        this.$router.push(redirectTo)
            //    } catch (err) {
            //        this.hasErrors = true;
            //        throw Error('Client-side validation failed' + err);
            //    }
            //},

            async validdateChangePassword() {
                this.$validator
                    .validateAll()
                    .then((password, newPassword) => {
                        this.hasErrors = false;
                        const { Email, Password } = this.user;

                        const { data } = this.$http.post('/api/account/changePassword', { Email: Email, currentPassword: Password, newPassword: this.newPassword })
                        let redirectTo = '/admin/'
                        this.$router.push(redirectTo)
                        // Validation success if response === true
                    })
                    .catch(error => {
                        // Catch errors
                        this.hasErrors = true;
                        throw new Error('Errors: ' + error)
                    })
            }
        }
    }
</script>
