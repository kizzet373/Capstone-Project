$('#textarea')
        .textext({
            plugins: 'tags autocomplete'
        })
        .bind('getSuggestions', function (e, data) {
                Hashtags,
                textext = $(e.target).textext()[0],
                query = (data ? data.query : '') || ''
            ;

            $(this).trigger(
                'setSuggestions',
                { result: textext.itemManager().filter(Hashtags, query) }
            );
        })
;