var FormWizard = function () {


    return {
        //main function to initiate the module
        init: function () {
            if (!jQuery().bootstrapWizard) {
                return;
            }

            // default form wizard
            $('#form_wizard_1').bootstrapWizard({
                'nextSelector': '.button-next',
                'previousSelector': '.button-previous',
                onTabClick: function (tab, navigation, index) {
                    //alert('on tab click disabled');
                    return false;
                },
                onNext: function (tab, navigation, index) {
                    var total = navigation.find('li').length;
                    var current = index + 1;
                    // set wizard title
                    $('.step-title', $('#form_wizard_1')).text('Step ' + (index + 1) + ' of ' + total);
                    // set done steps
                    jQuery('li', $('#form_wizard_1')).removeClass("done");
                    var li_list = navigation.find('li');
                    for (var i = 0; i < index; i++) {
                        jQuery(li_list[i]).addClass("done");
                    }

                    if (current == 1) {
                        $('#form_wizard_1').find('.button-previous').hide();
                    } else {
                        $('#form_wizard_1').find('.button-previous').show();
                    }

                    if (current >= total) {
                        $('#form_wizard_1').find('.button-next').hide();
                        $('#form_wizard_1').find('.button-submit').show();
                    } else {
                        $('#form_wizard_1').find('.button-next').show();
                        $('#form_wizard_1').find('.button-submit').hide();
                    }
                    App.scrollTo($('.page-title'));
                },
                onPrevious: function (tab, navigation, index) {
                    var total = navigation.find('li').length;
                    var current = index + 1;
                    // set wizard title
                    $('.step-title', $('#form_wizard_1')).text('Step ' + (index + 1) + ' of ' + total);
                    // set done steps
                    jQuery('li', $('#form_wizard_1')).removeClass("done");
                    var li_list = navigation.find('li');
                    for (var i = 0; i < index; i++) {
                        jQuery(li_list[i]).addClass("done");
                    }

                    if (current == 1) {
                        $('#form_wizard_1').find('.button-previous').hide();
                    } else {
                        $('#form_wizard_1').find('.button-previous').show();
                    }

                    if (current >= total) {
                        $('#form_wizard_1').find('.button-next').hide();
                        $('#form_wizard_1').find('.button-submit').show();
                    } else {
                        $('#form_wizard_1').find('.button-next').show();
                        $('#form_wizard_1').find('.button-submit').hide();
                    }

                    App.scrollTo($('.page-title'));
                },
                onTabShow: function (tab, navigation, index) {
                    var total = navigation.find('li').length;
                    var current = index + 1;
                    var $percent = (current / total) * 100;
                    $('#form_wizard_1').find('.bar').css({
                        width: $percent + '%'
                    });
                }
            });
            function reloadtab2() {
                $('#form_wizard_1').find('div#tab1').removeClass("active");
                $('#form_wizard_1').find('div#tab2').addClass("active");
                $('#form_wizard_1').find('li.active').removeClass("active");
                $('#form_wizard_1').find('a.active[href="#tab1"]').removeClass("active");
                $('#form_wizard_1').find('li.json').addClass("active");
                $('#form_wizard_1').find('li.active a').addClass("active");
                $('#form_wizard_1').find('div.bar').addClass("active");
                $('#form_wizard_1').find('.bar').css({ width: 50 + '%' });
            }

            function reloadtab4() {
                $('#form_wizard_1').find('div#tab2').removeClass("active");
                $('#form_wizard_1').find('div#tab4').addClass("active");
                $('#form_wizard_1').find('li.active').removeClass("active");
                $('#form_wizard_1').find('a.active[href="#tab4"]').removeClass("active");
                $('#form_wizard_1').find('li.jsonfour').addClass("active");
                $('#form_wizard_1').find('li.active a').addClass("active");
                $('#form_wizard_1').find('div.bar').addClass("active");
                $('#form_wizard_1').find('.bar').css({ width: 100 + '%' });
            }


            jQuery('#form_wizard_1 .reloadtab').live('click', function () {
                var activetab = $(".portlet .tools");
                var el = jQuery(activetab).parents(".portlet");

                App.blockUI(el);
                //reloadtab2();
                window.setTimeout(function () {
                    App.unblockUI(el);
                }, 1000);
            });

            $('#form_wizard_1').find('.button-previous').hide();
            $('#form_wizard_1 .button-submit').click(function () {
                //alert('Finished! Hope you like it :)');
            }).hide();
        }

    };

} ();