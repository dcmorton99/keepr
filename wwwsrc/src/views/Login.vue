<template>
    <div class="login container-fluid">
        <div class="row">
            <div class="col justify-content-center">
                <div class="card">
                    <form v-if="loginForm" @submit.prevent="loginUser">
                        <input type="email" v-model="creds.email" placeholder="email">
                        <br>
                        <input type="password" v-model="creds.password" placeholder="password">
                        <br>
                        <button class="btn-sm btn-secondary m-2" type="submit">Login</button>
                    </form>
                    <form v-else @submit.prevent="register">
                        <input type="text" v-model="newUser.username" placeholder="name">
                        <input type="email" v-model="newUser.email" placeholder="email">
                        <input type="password" v-model="newUser.password" placeholder="password">
                        <button type="submit">Create Account</button>
                    </form>
                    <div @click="loginForm = !loginForm">
                        <p v-if="loginForm">No account? Click to Register</p>
                        <p v-else>Already have an account click to Login</p>
                    </div>
                    <router-link :to="{name: 'home'}"><button class="btn btn-secondary m-2">View Keeps Anyway</button>
                    </router-link>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: "login",
        data() {
            return {
                loginForm: true,
                creds: {
                    email: "",
                    password: ""
                },
                newUser: {
                    email: "",
                    password: "",
                    username: ""
                }
            };
        },
        beforeCreate() {
            if (this.$store.state.user.id) {
                this.$router.push({ name: "home" })
            }
        },
        methods: {
            register() {
                this.$store.dispatch("register", this.newUser);
            },
            loginUser() {
                this.$store.dispatch("login", this.creds);
            }
        }
    };
</script>