describe('"Mapa de Carreiras" tests', function() {
    it('Home tests', function() {
        browser.get('http://localhost:4200/app/home');

        let role = element(by.id('37'));
        expect(role.getText()).toBe('Analista III de Qualidade');
    });

    it('Modal tests - table', function() {
        browser.get('http://localhost:4200/app/home');
        element(by.id('37')).click();

        let techniques = element(by.id('Técnicas de testes'));
        expect(techniques.getText()).toBe('Técnicas de testes');

        let logic = element(by.id('Lógica de Programação'));
        expect(logic.getText()).toBe('Lógica de Programação');

        let rules = element(by.id('Regras de Negócio'));
        expect(rules.getText()).toBe('Regras de Negócio');

        let lang_program = element(by.id('Linguagem de Programação'));
        expect(lang_program.getText()).toBe('Linguagem de Programação');
        
        browser.sleep(2000);
    });
});