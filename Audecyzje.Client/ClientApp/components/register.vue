<template>
    <div class="container">
        <div class="col-6 py-5 mx-auto">
            <h2 class="mb-2">Zarejestruj użytkownika</h2>
            <form @submit.prevent="Register" autocomplete="off">
                <div class="form-group with-icon-right">

                    <div class="input-group">
                        <label for="password">Email</label>
                        <input name="email" v-model="email" class="form-control" required />
                    </div>
                </div>
                <div class="input-group">
                    <label for="password">Hasło</label>
                    <input v-model="password" class="form-control" type="password" />
                </div>
                <button class="btn btn-success form-control mt-2" @click="signIn">Rejestruj</button>
            </form>
        </div>
    </div>
</template>

<script>
    import router from 'vue-router'
    import { Auth } from 'aws-amplify'

    export default {
        name: 'Register',
        data() {
            return {
                email: "",
                password: ""
            }
        },
        computed: {
            signIn() {
                return this.$store.state.signIn;
            }
        },
        methods: {
            signIn() {
                Auth.signIn(this.email, this.password)
                    .then(user => {
                        this.$store.state.signIn = !!user;
                        this.$store.state.user = user;
                    })
                    .catch(err => console.log(err));
            }
        },
        async Register() {
            var result = await this.$http.post('/api/account/AddAccount', { email: this.email, password: this.password });
            let redirectTo = '/admin'
            this.$router.push(redirectTo)
        }
    }
</script>
