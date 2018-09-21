
function MetaModal(param_user) 
{
    this.param = param_user || 
    { 
        elemento:  '#msgModal',
        header:    '',
        body:      '',
        footer:    '',
        btnOK:     '#modalOk',
        initModal: 'show',
        onSim:     '',
        onNao:     '',
        onOK:      '',
        keyboard:  true,
        backdrop:  true
    };

    this._init(this.param);
}

MetaModal.prototype = 
{
    _init: function (param) 
    {
        if (typeof param.elemento != 'string')
            param.elemento = '#msgModal';

        if (typeof param.btnOK != 'string')
            param.btnOK = '';

        if (typeof param.header != 'string')
            param.header = '';

        if (typeof param.body != 'string')
            param.body = '';

        if (typeof param.footer != 'string')
            param.footer = '';

        if (typeof param.initModal != 'string')
            param.initModal = 'show';

        if (typeof param.btnSim != 'string')
            param.btnSim = '';

        if (typeof param.btnNao != 'string')
            param.btnNao = '';
        
        if (typeof param.onSim == 'function')
            this._onSim = param.onSim;

        if (typeof param.onNao == 'function')
            this._onNao = param.onNao;

        if (typeof param.onOK == 'function')
            this._onOK = param.onOK;

        if (typeof param.keyboard != 'boolean')
            param.keyboard = true;

        if (typeof param.backdrop != 'boolean')
            param.backdrop = true;

        $(param.elemento + ' .modal-header').html(param.header);
        $(param.elemento + ' .modal-body').html(param.body);
        $(param.elemento + ' .modal-footer').html(param.footer);

        if ((typeof param.onSim != 'undefined') && (typeof param.onNao != 'undefined'))
        {
            $(param.btnSim).click(this.param, this._onSim);
            $(param.btnNao).click(this.param, this._onNao);            
        }
        else
        {
            $(param.btnOK).click(this.param, this._onOK);
        }
    },

    fechar: function() 
    {
        $(this.param.elemento).modal('hide');
    },

    exibir: function () 
    {
        if(this.param.keyboard || this.param.backdrop)
            $(this.param.elemento).modal({ keyboard: this.param.keyboard, backdrop: this.param.backdrop });
        else
            $(this.param.elemento).modal(this.param.initModal);
    },

    _onOK : function (e) { },

    _onSim: function (e) { },

    _onNao: function (e) { }
};