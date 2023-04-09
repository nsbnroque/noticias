package com.noticias.config;

import org.neo4j.driver.Driver;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.data.neo4j.core.ReactiveDatabaseSelectionProvider;
import org.springframework.data.neo4j.core.transaction.ReactiveNeo4jTransactionManager;

@Configuration
public class ReactiveConfiguration {

    @Bean
    public ReactiveNeo4jTransactionManager reactiveNeo4jTransactionManager(Driver driver, ReactiveDatabaseSelectionProvider databaseSelectionProvider){
        return new ReactiveNeo4jTransactionManager(driver, databaseSelectionProvider);
    }
    
}
