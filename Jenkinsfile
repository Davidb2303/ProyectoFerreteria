pipeline {
    agent any

    stages {
        stage('Restore') {
            steps {
                sh 'dotnet restore'
            }
        }

        stage('Test') {
            steps {
                sh 'dotnet test --configuration Release'
            }
        }
    }
}
